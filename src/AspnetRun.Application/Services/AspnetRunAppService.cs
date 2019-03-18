using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Services
{
    public class AspnetRunAppService<TEntity> : IAspnetRunAppService<TEntity> where TEntity : BaseEntity
    {
        // TODO : validation , authorization, logging etc. -- cross cutting activities in here.
        protected readonly IAsyncRepository<TEntity> _repository;
        protected readonly IAppLogger<TEntity> _logger;

        public AspnetRunAppService(IAsyncRepository<TEntity> repository, IAppLogger<TEntity> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
