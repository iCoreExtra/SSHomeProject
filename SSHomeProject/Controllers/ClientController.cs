using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSHomeProject.Models;
using SSHomeCommon.Helpers;
using SSHomeDataModel;
using SSHomeCommon;
using SSHomeBusinessLayerTypes;
using SSHomeDatalayerCommon;
using SSHomeCommon.Enums;
using SSHomeCommon.Constants;

namespace SSHomeProject.Controllers
{
    public class ClientController : Controller
    {
        #region class members
        private IClientMasterBL _clientService;
        #endregion

        #region Constructors for dependency injections
        public ClientController(IClientMasterBL clientservice)
        {
            _clientService = clientservice;
        }
        #endregion Constructors for dependency injections

        #region Controller Actions
        [HttpGet]
        public ActionResult Create()
        {
            ClientMasterViewModel model = new ClientMasterViewModel();
            model.Mode = PageMode.Add;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ClientMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<ClientMaster> result = null;

                    model.Mode = PageMode.Add;
                    ClientMaster clientdetails = new ClientMaster();
                    ConvertViewModelToDomainObject(model, clientdetails);
                    result = _clientService.Add(clientdetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionClientList);
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
                catch (Exception ex)
                {
                    SSHomeLogger.LogException(ex);
                }
            }
            model.Mode = PageMode.Add;
            return View(model);
        }

        public ActionResult Details(int clientId)
        {
           ClientMasterViewModel model = new ClientMasterViewModel();
            try
            {
                ClientMaster clientDetails = _clientService.GetClientDetails(clientId);
                ConvertDomainObjectToViewModel(model, clientDetails);
                model.Mode = PageMode.Details;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionClientCreate, model);
        }

        public ActionResult ClientList(ClientListViewModel clientViewDatails)
        {
            try
            {
                IEnumerable<ClientMaster> clientList = _clientService.GetClientListAll();
                ConvertDataObjectModelToViewModel(clientList, clientViewDatails);
                return View(clientViewDatails);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        public ActionResult Edit(int clientId)
        {
            ClientMasterViewModel model = new ClientMasterViewModel();
            try
            {
                ClientMaster clientDetails = _clientService.GetClientDetails(clientId);
            
                ConvertDomainObjectToViewModel(model, clientDetails);
                model.Mode = PageMode.Edit;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionClientEdit, model);
        }

        [HttpPost]
        public ActionResult Edit(ClientMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<ClientMaster> result = null;

                    ClientMaster clientdetails = new ClientMaster();
                    ConvertViewModelToDomainObject(model, clientdetails);
                    clientdetails.ClientId = model.ClientId;
                    result = _clientService.ClientUpdate(clientdetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionClientList);
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
                catch (Exception ex)
                {
                    SSHomeLogger.LogException(ex);
                }
            }
            return View();
        }

        #endregion

        #region Conversion Methods
        private void ConvertViewModelToDomainObject(ClientMasterViewModel model, ClientMaster clientdetails)
        {
            clientdetails.FirstName = model.FirstName;
            clientdetails.LastName = model.LastName;
            clientdetails.CompanyName = model.CompanyName;
            clientdetails.Number1 = model.Number1;
            clientdetails.Number2 = model.Number2;
            clientdetails.Email1 = model.Email1;
            clientdetails.Email2 = model.Email2;
            clientdetails.DateOfBirth = model.DateOfBirth;
            clientdetails.Anniversary = model.Anniversary;
            clientdetails.Profession = model.Profession;
            clientdetails.ReferralId = model.ReferralId;
            clientdetails.StoreId = model.StoreId;
            clientdetails.CustomerTypeId = model.CustomerTypeId;

            AddressMaster clientAddress = new AddressMaster();
            clientAddress.AddressLine1 = model.AddressLine1;
            clientAddress.AddressLine2 = model.AddressLine2;
            clientAddress.CityId = model.CityId;
            clientAddress.Pincode = model.Pincode;

            //Make a List Address
            clientdetails.ClientAddressList = new List<AddressMaster>();
            clientdetails.ClientAddressList.Add(clientAddress);
        }

        private void ConvertDomainObjectToViewModel(ClientMasterViewModel model, ClientMaster clientDetails)
        {
            model.ClientId = clientDetails.ClientId;
            model.FirstName = clientDetails.FirstName;
            model.LastName = clientDetails.LastName;
            model.CompanyName = clientDetails.CompanyName;
            model.Number1 = clientDetails.Number1;
            model.Number2 = clientDetails.Number2;
            model.Email1 = clientDetails.Email1;
            model.Email2 = clientDetails.Email2;
            model.DateOfBirth = clientDetails.DateOfBirth;
            model.Anniversary = clientDetails.Anniversary;
            model.Profession = clientDetails.Profession;
            model.ReferralId = clientDetails.ReferralId;
            model.StoreId = clientDetails.StoreId;
            model.CustomerTypeId = clientDetails.CustomerTypeId;
        }

        private void ConvertDataObjectModelToViewModel(IEnumerable<ClientMaster> clientList, ClientListViewModel clientViewDatails)
        {
            clientViewDatails.ClientList = clientList.Select(x => new ClientMaster()
            {
                ClientId = x.ClientId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CompanyName = x.CompanyName,
                Number1 = x.Number1,
                Email1 = x.Email1
            }).ToList();
        }
        #endregion
    }
}