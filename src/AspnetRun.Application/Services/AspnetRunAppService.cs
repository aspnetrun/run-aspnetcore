using AspnetRun.Application.Dtos;
using AspnetRun.Application.Infrastructure.Mapper;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class AspnetRunAppService<TEntity, TEntityDto> : IAspnetRunAppService<TEntity, TEntityDto> where TEntity : BaseEntity where TEntityDto : BaseDto
    {
        // TODO : validation , authorization, logging etc. -- cross cutting activities in here.
        protected readonly IAsyncRepository<TEntity> _repository;
        protected readonly IAppLogger<TEntity> _logger;

        public AspnetRunAppService(IAsyncRepository<TEntity> repository, IAppLogger<TEntity> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public virtual async Task<TEntity> Add(TEntityDto entityDto)
        {
            var existingEntity = _repository.GetByIdAsync(entityDto.Id); 
            if (existingEntity != null)
                throw new ApplicationException($"{entityDto.ToString()} with this id already exists");

            var mappedEntity = ObjectMapper.Mapper.Map<TEntity>(entityDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _repository.AddAsync(mappedEntity);
            return newEntity;
        }

        // TODO : here - try to add these values in here

        //public CustomerDto Add(CustomerDto customerDto)
        //{
        //    ISpecification<Customer> alreadyRegisteredSpec =
        //        new CustomerAlreadyRegisteredSpec(customerDto.Email);

        //    Customer existingCustomer = this.customerRepository.FindOne(alreadyRegisteredSpec);

        //    if (existingCustomer != null)
        //        throw new Exception("Customer with this email already exists");

        //    Country country = this.countryRepository.FindById(customerDto.CountryId);

        //    Customer customer =
        //        Customer.Create(customerDto.FirstName, customerDto.LastName, customerDto.Email, country);

        //    this.customerRepository.Add(customer);
        //    this.unitOfWork.Commit();

        //    return AutoMapper.Mapper.Map<Customer, CustomerDto>(customer);
        //}

        //public void Update(CustomerDto customerDto)
        //{
        //    if (customerDto.Id == Guid.Empty)
        //        throw new Exception("Id can't be empty");

        //    ISpecification<Customer> registeredSpec =
        //        new CustomerRegisteredSpec(customerDto.Id);

        //    Customer customer = this.customerRepository.FindOne(registeredSpec);

        //    if (customer == null)
        //        throw new Exception("No such customer exists");

        //    customer.ChangeEmail(customerDto.Email);
        //    this.unitOfWork.Commit();
        //}

        //public void Remove(Guid customerId)
        //{
        //    ISpecification<Customer> registeredSpec =
        //        new CustomerRegisteredSpec(customerId);

        //    Customer customer = this.customerRepository.FindOne(registeredSpec);

        //    if (customer == null)
        //        throw new Exception("No such customer exists");

        //    this.customerRepository.Remove(customer);
        //    this.unitOfWork.Commit();
        //}

        //public CustomerDto Get(Guid customerId)
        //{
        //    ISpecification<Customer> registeredSpec =
        //        new CustomerRegisteredSpec(customerId);

        //    Customer customer = this.customerRepository.FindOne(registeredSpec);

        //    return AutoMapper.Mapper.Map<Customer, CustomerDto>(customer);
        //}

    }
}
