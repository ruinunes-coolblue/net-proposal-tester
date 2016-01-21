using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using net_coolblue_datastore_clients.RavenDb;

using PurchaseProposalTester.Entities;

using Raven.Client.Document;

namespace PurchaseProposalTester
{
    public partial class TesterForm : Form
    {
        private readonly DocumentStore _documentStore;
        private readonly RavenRepository<ProductStockInformationEntity, int> _productRepository;
        private readonly RavenRepository<PurchaseProposalEntity, int> _proposalRepository;

        private decimal _activeMailConversion;
        private int _availableStock;
        private int _containerQuantity;
        private bool _mandatoryContainerQuantity;
        private int _preparedToOrderQuantity;

        private int _productId;
        private int _purchaseOrderQuantity;
        private decimal _weeklySalesForecast;

        public TesterForm()
        {
            InitializeComponent();
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

            if(!int.TryParse(containerQuantityValue, out _containerQuantity))
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

            var weeklySalesForecastValue = txtWeeklySalesForecast.Text;

            if(!decimal.TryParse(weeklySalesForecastValue, out _weeklySalesForecast))
                _weeklySalesForecast = 0;

            RecalculateSoq();
        }

        private void txtWeeklySalesForecast_Leave(object sender, EventArgs e)
        {
            txtWeeklySalesForecast.Text = _weeklySalesForecast.ToString(CultureInfo.InvariantCulture);
        }

        private void RecalculateSoq()
        {
            const int STOCK_WEEKS_THRESHOLD = 3;

            decimal calculatedSuggestedQuantity = (_weeklySalesForecast * STOCK_WEEKS_THRESHOLD)
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

            DateTime oldestProposalDate;
            var existingProposals = _proposalRepository.QueryAll(proposal => proposal.Accepted == false).ToList();
            if(existingProposals.Any())
                oldestProposalDate = existingProposals.Select(proposal => proposal.CreatedAt).Min();
            else
                oldestProposalDate = DateTime.Now;

            var newProposal = _proposalRepository.Create(new PurchaseProposalEntity
                                                         {
                                                             ProductId = _productId,
                                                             Accepted = false,
                                                             AcceptedData = null,
                                                             CreatedAt =
                                                                 oldestProposalDate.Subtract(new TimeSpan(0, 0, 1)),
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
    }
}