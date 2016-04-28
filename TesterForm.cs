using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using net_coolblue_datastore_clients.RavenDb;

using PurchaseProposalTester.Entities;

using Raven.Abstractions.Extensions;
using Raven.Client.Document;

namespace PurchaseProposalTester
{
    public partial class TesterForm : Form
    {
        private readonly DocumentStore _documentStore;
        private readonly RavenRepository<ProductStockInformationEntity, int> _productRepository;
        private readonly RavenRepository<PurchaseProposalEntity, int> _proposalRepository;

        private decimal _activeMailConversion = 0;
        private int _availableStock = 1;
        private int _containerQuantity = 1;
        private bool _mandatoryContainerQuantity = false;
        private int _preparedToOrderQuantity = 2;

        private int _productId = 450958;
        private List<int> _productGroupIds = new List<int>() {5285};
        private int _purchaseOrderQuantity = 1;
        private decimal _weeklySalesForecast = 3.85m;

        private readonly int _stockDaysThreshold;

        public TesterForm()
        {
            InitializeComponent();
            ResetFields();

            _documentStore = new DocumentStore
                             {
                                 ConnectionStringName =
                                     "RavenDbConnection",
                                 Conventions = new DocumentConvention
                                               {
                                                   DefaultQueryingConsistency =
                                                       ConsistencyOptions.AlwaysWaitForNonStaleResultsAsOfLastWrite
                                               }
                             };
            _productRepository = new RavenRepository<ProductStockInformationEntity>(_documentStore);
            _proposalRepository = new RavenRepository<PurchaseProposalEntity>(_documentStore);

            _stockDaysThreshold = int.Parse(ConfigurationManager.AppSettings["StockDaysThreshold"]);
        }

        private void ResetFields()
        {
            txtProductGroup.Text = string.Join(",", _productGroupIds);
            txtActiveMailConversion.Text = _activeMailConversion.ToString(CultureInfo.InvariantCulture);
            txtContainerQuantity.Text = _containerQuantity.ToString();
            txtPreparedToOrder.Text = _preparedToOrderQuantity.ToString();
            txtProductID.Text = _productId.ToString();
            txtPurchaseOrder.Text = _purchaseOrderQuantity.ToString();
            txtStock.Text = _availableStock.ToString();
            txtWeeklySalesForecast.Text = _weeklySalesForecast.ToString(CultureInfo.InvariantCulture);
            chkMandatoryContainerQuantity.Checked = _mandatoryContainerQuantity;
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            var productIdValue = txtProductID.Text;

            if(!int.TryParse(productIdValue, out _productId))
                _productId = 0;

            RecalculateSoq();
        }

        private void txtProductID_Leave(object sender, EventArgs e)
        {
            txtProductID.Text = _productId.ToString();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            var stockValue = txtStock.Text;

            if(!int.TryParse(stockValue, out _availableStock))
                _availableStock = 0;

            RecalculateSoq();
        }

        private void txtStock_Leave(object sender, EventArgs e)
        {
            txtStock.Text = _availableStock.ToString();
        }

        private void txtPurchaseOrder_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            var purchaseOrderValue = txtPurchaseOrder.Text;

            if(!int.TryParse(purchaseOrderValue, out _purchaseOrderQuantity))
                _purchaseOrderQuantity = 0;

            RecalculateSoq();
        }

        private void txtPurchaseOrder_Leave(object sender, EventArgs e)
        {
            txtPurchaseOrder.Text = _purchaseOrderQuantity.ToString();
        }

        private void txtPreparedToOrder_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            var preparedToOrderValue = txtPreparedToOrder.Text;

            if(!int.TryParse(preparedToOrderValue, out _preparedToOrderQuantity))
                _preparedToOrderQuantity = 0;

            RecalculateSoq();
        }

        private void txtPreparedToOrder_Leave(object sender, EventArgs e)
        {
            txtPreparedToOrder.Text = _preparedToOrderQuantity.ToString();
        }

        private void txtActiveMailConversion_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            var activeMailConversionValue = txtActiveMailConversion.Text;

            if(!decimal.TryParse(activeMailConversionValue, out _activeMailConversion))
                _activeMailConversion = 0;

            RecalculateSoq();
        }

        private void txtActiveMailConversion_Leave(object sender, EventArgs e)
        {
            txtActiveMailConversion.Text = _activeMailConversion.ToString(CultureInfo.InvariantCulture);
        }

        private void txtContainerQuantity_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            var containerQuantityValue = txtContainerQuantity.Text;

            if(!int.TryParse(containerQuantityValue, out _containerQuantity) || _containerQuantity < 1)
                _containerQuantity = 1;

            RecalculateSoq();
        }

        private void txtContainerQuantity_Leave(object sender, EventArgs e)
        {
            if(_containerQuantity < 1)
                _containerQuantity = 1;

            txtContainerQuantity.Text = _containerQuantity.ToString();
        }

        private void txtWeeklySalesForecast_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            var weeklySalesForecastValue = txtWeeklySalesForecast.Text.Replace(',', '.');

            if(!decimal.TryParse(weeklySalesForecastValue, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _weeklySalesForecast))
                _weeklySalesForecast = 0;

            RecalculateSoq();
        }

        private void txtWeeklySalesForecast_Leave(object sender, EventArgs e)
        {
            txtWeeklySalesForecast.Text = _weeklySalesForecast.ToString(CultureInfo.InvariantCulture);
        }

        private void RecalculateSoq()
        {
            const int DAYS_IN_WEEK = 7;

            decimal calculatedSuggestedQuantity = ((_weeklySalesForecast / DAYS_IN_WEEK) * _stockDaysThreshold)
                                                  + _activeMailConversion
                                                  - _availableStock
                                                  - _purchaseOrderQuantity
                                                  - _preparedToOrderQuantity;

            var roundedCalculatedSuggestedQuantity = calculatedSuggestedQuantity < 1
                ? (int)Math.Ceiling(calculatedSuggestedQuantity)
                : (int)Math.Round(calculatedSuggestedQuantity);

            if(_mandatoryContainerQuantity)
            {
                roundedCalculatedSuggestedQuantity = RoundSoqToContainer(roundedCalculatedSuggestedQuantity,
                    _containerQuantity);
            }

            lblExpectedOriginalSOQ.Text = calculatedSuggestedQuantity.ToString(CultureInfo.InvariantCulture);
            lblExpectedSOQ.Text = roundedCalculatedSuggestedQuantity.ToString();
        }

        private void ClearMessages()
        {
            lblError.Text = string.Empty;
            lblOkMsg.Text = string.Empty;
        }

        private void btnCreateUpdateProduct_Click(object sender, EventArgs e)
        {
            ClearMessages();

            if(_productId == 0)
            {
                lblError.Text = "You need at least a product ID. Put it in there!";
                return;
            }

            var productInformation = new ProductStockInformationEntity
                                     {
                                         Id = _productId,
                                         ProductGroupIds = _productGroupIds,
                                         ActiveMailConversion = _activeMailConversion,
                                         AvailableStock = _availableStock,
                                         ContainerQuantity = _containerQuantity,
                                         PreparedToOrderQuantity = _preparedToOrderQuantity,
                                         PurchaseOrderQuantity = _purchaseOrderQuantity,
                                         WeeklySalesForecast = _weeklySalesForecast
                                     };

            _productRepository.Create(productInformation);

            //Delete all old (non-accepted) proposals for this product
            var oldProposals =
                _proposalRepository.QueryAll(prop => prop.Accepted == false && prop.ProductId == _productId);

            foreach(var proposal in oldProposals)
                _proposalRepository.Delete(proposal.Id);

            var newProposal = _proposalRepository.Create(new PurchaseProposalEntity
                                                         {
                                                             ProductId = _productId,
                                                             ProductGroupIds = _productGroupIds,
                                                             Accepted = false,
                                                             AcceptedData = null,
                                                             CreatedAt = DateTime.Now,
                                                             Delivered = false
                                                         });

            if(newProposal != null)
                lblOkMsg.Text = $"Proposal Created successfully with ID {newProposal.Id}";
            else
                lblError.Text = "Proposal not created, some error occurred";
        }

        private void chkMandatoryContainerQuantity_CheckedChanged(object sender, EventArgs e)
        {
            _mandatoryContainerQuantity = chkMandatoryContainerQuantity.Checked;
            RecalculateSoq();
        }

        private int RoundSoqToContainer(int orderQuantity, int containerQuantity)
        {
            var isSuggestedQuantityDivisibleByContainerQuantity = (orderQuantity % containerQuantity == 0);
            int suggestedOrderQuantityRoundedToContainer;

            if(isSuggestedQuantityDivisibleByContainerQuantity)
                suggestedOrderQuantityRoundedToContainer = orderQuantity;
            else
            {
                suggestedOrderQuantityRoundedToContainer = ((orderQuantity +
                                                             containerQuantity) / containerQuantity) *
                                                           containerQuantity;
            }


            return suggestedOrderQuantityRoundedToContainer;
        }

        private void txtProductGroup_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();

            int gid = 0;

            _productGroupIds = txtProductGroup.Text
                                              .Split(',')
                                              .Select(p =>
                                              {
                                                  int.TryParse(p.Trim(), out gid);
                                                  return gid;
                                              })
                                              .Where(_ => gid > 0).ToList();

            RecalculateSoq();
        }
    }
}