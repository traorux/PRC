﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PRC.CORE;
using PRC.CORE.Media.Call;
using PRC.CORE.Model;
using PRC.CORE.Repository;
using PRC.CORE.Service;
using PRC.PROCESS.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.SERVICE
{
    public class MediaService : IMediaService
    {
        private readonly ICallRepository callRepository;
        private readonly IExtensionRepository extensionRepository;
        private readonly IStateRepository stateRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IDataCustomRepository dataCustomRepository;
        private readonly IRequestRepository requestRepository;
        private readonly IHistoryRepository historyRepository;
        private readonly IMediaCall mediaCall;


        public MediaService(IMediaCall mediaCall, ICallRepository callRepository,
            IExtensionRepository extensionRepository, ICustomerRepository customerRepository,
            IStateRepository stateRepository, IDataCustomRepository dataCustomRepository,
            IRequestRepository requestRepository, IHistoryRepository historyRepository)
        {
            this.callRepository = callRepository;
            this.extensionRepository = extensionRepository;
            this.customerRepository = customerRepository;
            this.stateRepository = stateRepository;
            this.dataCustomRepository = dataCustomRepository;
            this.requestRepository = requestRepository;
            this.historyRepository = historyRepository;
            this.mediaCall = mediaCall;

        }


        ///Call  Services ------------------------------------------------------------------------------
        public async Task<bool> DropeCall()
        {
            return await mediaCall.BasicDropMeAsync("891");
        }


        public async Task<bool> MakeOutgoingCall(Call call)
        {
            return await mediaCall.BasicMakeCallAsync(call.ExtensionNumber, call.CustomerNumber);
        }

        public Call Startoutgoingcall(Call call)
        {
            return call;

        }

        //Enregistrement des infos reception d'appel (appel entrant)
        public async Task<Call> IncomingRingingCall(Call call)
        {
            var extension = await extensionRepository.GetExtensionById(call.ExtensionNumber);
            var customer = await customerRepository.GetCustomerByNumber(call.CustomerNumber);
            if (extension != null && customer != null)
            {

                call.ExtensionNumber = extension.Number;
                call.IdCustomer = customer.IdCustomer;
                await callRepository.AddCall(call);
                call.Customer.DataCustom = await dataCustomRepository.GetDataCustomById(call.Customer.IdCustomer);
                return call;

            }
            if (extension != null && customer == null)
            {
                call.ExtensionNumber = extension.Number;
                Customer customer1 = new Customer();
                customer1.CustomerNumber = call.CustomerNumber;
                await customerRepository.AddCustomer(customer1);
                var newcustomer = await customerRepository.GetCustomerByNumber(customer1.CustomerNumber);
                if (newcustomer != null)
                {
                    call.IdCustomer = customer1.IdCustomer;
                }
                return await callRepository.AddCall(call);
            }
            if (extension == null && customer != null)
            {
                call.IdCustomer = customer.IdCustomer;
                Extension extension1 = new Extension();
                extension1.Number = call.ExtensionNumber;
                await extensionRepository.AddExtension(extension1);
                var newextension = await extensionRepository.GetExtensionById(extension1.Number);
                if (newextension != null)
                {
                    call.ExtensionNumber = extension1.Number;
                }
                return await callRepository.AddCall(call);
            }
            if (extension == null && customer == null)
            {
                call.IdCustomer = customer.IdCustomer;
                Extension extension1 = new Extension();
                extension1.Number = call.ExtensionNumber;
                await extensionRepository.AddExtension(extension1);

                Customer customer1 = new Customer();
                customer1.CustomerNumber = call.CustomerNumber;
                await customerRepository.AddCustomer(customer1);

                var newextension = await extensionRepository.GetExtensionById(extension1.Number);
                var newcustomer = await customerRepository.GetCustomerByNumber(customer1.CustomerNumber);
                if (newextension != null && newcustomer != null)
                {
                    call.ExtensionNumber = extension1.Number;
                    call.IdCustomer = customer1.IdCustomer;
                    return await callRepository.AddCall(call);
                }
                return null;
            }
            return null;
        }

        //Mise à jour action dans bd apres reponse appel entrant
        public async Task<Call> IncomingCallCommunication(Call call)
        {
            var callx = await callRepository.GetACallByCallRef(call.CallRef);
            if (callx != null)
            {
                var resp = await mediaCall.BasicAnswerCallAsync(callx.ExtensionNumber);
                if (resp != false)
                {
                    return await callRepository.UpdateCall(callx);
                }

                return callx;
            }
            return null;
        }

        // Mise à jour action dans bd apres reponse appel sortant
        public async Task<Call> OutgoingRingingCall(Call call)
        {
            var extension = await extensionRepository.GetExtensionById(call.ExtensionNumber);
            var customer = await customerRepository.GetCustomerByNumber(call.CustomerNumber);
            if (extension != null && customer != null)
            {
                call.ExtensionNumber = extension.Number;
                call.IdCustomer = customer.IdCustomer;
                return await callRepository.AddCall(call);
            }
            if (extension != null && customer == null)
            {
                call.ExtensionNumber = extension.Number;
                Customer customer1 = new Customer();
                customer1.CustomerNumber = call.CustomerNumber;
                await customerRepository.AddCustomer(customer1);
                var newcustomer = await customerRepository.GetCustomerByNumber(customer1.CustomerNumber);
                if (newcustomer != null)
                {
                    call.IdCustomer = customer1.IdCustomer;
                }
                return await callRepository.AddCall(call);
            }
            if (extension == null && customer != null)
            {
                call.IdCustomer = customer.IdCustomer;
                Extension extension1 = new Extension();
                extension1.Number = call.ExtensionNumber;
                await extensionRepository.AddExtension(extension1);
                var newextension = await extensionRepository.GetExtensionById(extension1.Number);
                if (newextension != null)
                {
                    call.ExtensionNumber = extension1.Number;
                }
                return await callRepository.AddCall(call);
            }
            if (extension == null && customer == null)
            {
                call.IdCustomer = customer.IdCustomer;
                Extension extension1 = new Extension();
                extension1.Number = call.ExtensionNumber;
                await extensionRepository.AddExtension(extension1);

                Customer customer1 = new Customer();
                customer1.CustomerNumber = call.CustomerNumber;
                await customerRepository.AddCustomer(customer1);

                var newextension = await extensionRepository.GetExtensionById(extension1.Number);
                var newcustomer = await customerRepository.GetCustomerByNumber(customer1.CustomerNumber);
                if (newextension != null && newcustomer != null)
                {
                    call.ExtensionNumber = extension1.Number;
                    call.IdCustomer = customer1.IdCustomer;
                    return await callRepository.AddCall(call);
                }
                return null;
            }
            return null;
        }
        public async Task<Call> EndCall(Call call)
        {
            var callx = await callRepository.GetACallByCallRef(call.CallRef);
            if (callx != null)
            {
                return await callRepository.UpdateCall(callx);
            }
            return null;
        }
        public async Task<Call> OutgoingCallCommunication(Call call)
        {
            var callx = await callRepository.GetACallByCallRef(call.CallRef);
            if (callx != null)
            {
                return await callRepository.UpdateCall(callx);
            }
            return null;
        }

        ///Extension  Services ------------------------------------------------------------------------------
        ///
        public async Task<bool> CreateExtension(Extension extension)
        {
            var newextension = await extensionRepository.GetExtensionById(extension.Number);
            if (newextension.Number == null)
            {
                return await extensionRepository.AddExtension(extension);
            }
            return false;
        }


        public void DeleteExtension(Extension extension)
        {
            extensionRepository.DeleteExtension(extension);
        }

        public async Task<IEnumerable<Extension>> GetExtensionsList()
        {
            return await extensionRepository.GetAllExtension();
        }

        public async Task<bool> UpdateExtension(Extension extension)
        {
            var newextension = await extensionRepository.GetExtensionById(extension.Number);
            if (newextension.Number != null)
            {
                newextension.Password = extension.Password;
                return await extensionRepository.UpdateExtension(newextension);
            }
            else
                return await extensionRepository.AddExtension(extension);
        }

       

        ///Customer  Services ------------------------------------------------------------------------------
        public async Task<bool> CreateCustomer(Customer customer)
        {
            var newcustomer = await customerRepository.GetCustomerByNumber(customer.CustomerNumber);
            if (newcustomer.CustomerNumber == null)
            {
                return await customerRepository.AddCustomer(customer);
            }
            return false;
        }

        public async Task<Customer> SearchCustomer(string customerNumber)
        {
            var customer = await customerRepository.GetCustomerByNumber(customerNumber);
            if (customer == null)
            {
                //return "Numero non enregistré";
            }
            else
                customer.DataCustom = await dataCustomRepository.GetDataCustomById(customer.IdCustomer);
            return customer;

        }
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var newcustomer = await customerRepository.GetCustomerByNumber(customer.CustomerNumber);
            if (newcustomer.CustomerNumber != null)
            {
                newcustomer.LastName = customer.LastName;
                newcustomer.FirstName = customer.FirstName;
                return await customerRepository.UpdateCustomer(newcustomer);
            }
            else
                return await customerRepository.AddCustomer(customer);
        }

        public async Task<IEnumerable<Call>> GetCallsList()
        {
            return await callRepository.GetAllCall();
        }

            

        public async Task<Request> CreateRequest(Request request)
        {
            return await requestRepository.AddRequest(request);
        }

        public async Task<IEnumerable<Call>> GetHistsList(string customerNumber)
        {
            return await callRepository.GetHistCall(customerNumber);
        }

        public async Task<ICollection<History>> GetHistories(string customerNumber)
        {
            return await historyRepository.GetHistories(customerNumber);
        }

        public async Task<Call> GetCallInfos(string CallRef)
        {
            return await callRepository.GetACallByCallRef(CallRef);
        }
    }

}
