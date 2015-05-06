using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EATL.BLL.Facade;
using EATL.DAL;
using EATL.SupportFramework;
using EATL.WebClient.HelperClass;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EATL.WebClient.CommonUI
{
    public partial class rptSolarHomePlacingStoredAndAttainment : System.Web.UI.Page
    {
        SessionObjects oSessionObjects = new SessionObjects();
        string _ConnectionString = ConfigurationSettings.AppSettings["DBConnectionString"].ToString();
        EnumCollection.ReportLevel RptLevel = EnumCollection.ReportLevel.Level0;
        int _ZoomFactor = 100;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oSessionObjects.Init_Meghna_LoginID();
                this.lblWarning.Text = "";
                LoadBranch();
            }
        }

        private void LoadBranch()
        {
            try
            {
                using (GeneralConfigurationFacade _facade = new GeneralConfigurationFacade())
                {
                    List<Branch> branchList = new List<Branch>();
                    branchList = _facade.GetBranchInfoAll();
                    DDLHelper.Bind<Branch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.BranchName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                string _BranchName = string.Empty;
                string _reporttitle = string.Empty;
                string _CommandText = string.Empty;

                string StartDate = txtFromDate.Text;
                DateTime _FromDate = new DateTime();
                _FromDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string EndDate = txtToDate.Text;
                DateTime _ToDate = new DateTime();
                _ToDate = DateTime.ParseExact(EndDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                _BranchName = Convert.ToString(ddlBranch.SelectedItem);
                decimal _BranchID = Convert.ToDecimal(ddlBranch.SelectedValue);
                _reporttitle = "Solar Home System Placing,Stored & Attainment Report";

                SqlParameter[] _SqlParameters = null;
                _CommandText = "SolarHomeSystemPlacingStoredAndAttainment";
                _SqlParameters = new SqlParameter[] 
                    {
                        new SqlParameter("@BranchID", _BranchID),
                        new SqlParameter("@StartDate", _FromDate),
                    };

                DbResult<SqlConnection> oDbResult = new DbResult<SqlConnection>(_ConnectionString, CommandType.StoredProcedure, _CommandText, _SqlParameters);
                DataSet oDataSet = oDbResult.oDataSet;
                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    CrystalReportUtility oCrystalReportUtility = new CrystalReportUtility();
                    oCrystalReportUtility.SetUniquePostfixName(this.RptLevel.ToString());
                    oCrystalReportUtility.CRParameterList("rpt_title", _reporttitle);
                    oCrystalReportUtility.CRParameterList("branchName", _BranchName);
                    oCrystalReportUtility.CRParameterList("fromDate", StartDate);
                    oCrystalReportUtility.CRParameterList("toDate", EndDate);
                    oCrystalReportUtility.SetRptDataTable(oDataSet.Tables[0]);

                    DataTable oDataTableXLS = oDataSet.Tables[0].Copy();
                    oCrystalReportUtility.SetRptPath(Server.MapPath(@"..\Reports\SolarHomePlacingStoredAndAttainmentReport.rpt"));
                    oCrystalReportUtility.SetRptDataTable(oDataSet.Tables[0]);
                    this.lblWarning.Text = "";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('ReportViewer.aspx?RptLevel=" + (int)this.RptLevel + "&&UniquePostfixName=" + oCrystalReportUtility.UniquePostfixName + "&&ReportTitle=" + _reporttitle + "&&ZoomFactor=" + _ZoomFactor + "');", true);
                }
                else
                {
                    this.lblWarning.Text = "No record found!";
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message.ToString();
				//this is test line for testing for git change
            }
            

         }
        
                
    }
}