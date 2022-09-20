using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Servicio.ConsultarCliente;

namespace Servicio
{
    public class Clientes
    {
        //string _id;
        QuerySupplierInClient cliente = new QuerySupplierInClient();
  

        public Clientes()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            cliente.ClientCredentials.UserName.UserName = "_OrionDiego";
            cliente.ClientCredentials.UserName.Password = "Diego12345";
        }
        public string  GetClient(string id) 
        {
            SupplierByElementsQueryMessage_sync request = new SupplierByElementsQueryMessage_sync();
            string rspst="";
            try
            {

                request.SupplierSelectionByElements = new SupplierByElementsQuerySelectionByElements ();

                request.SupplierSelectionByElements.SelectionByInternalID = new SelectionByIdentifier[0];
                request.SupplierSelectionByElements.SelectionByInternalID[0] = new SelectionByIdentifier();
                request.SupplierSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request.SupplierSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request.SupplierSelectionByElements.SelectionByInternalID[0].LowerBoundaryIdentifier = "S100800";



                var response = cliente.FindByElements(request);

                rspst = response.Supplier[0].FirstLineName;
                return rspst;
            }
            catch (Exception ex )
            {

                return rspst = ex.Message;
            }








            

        }

    }
}
