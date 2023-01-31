using Microsoft.Extensions.Options;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Intefaces;
using MobileDriverApp.Models;
using MobileDriverApp.Models.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Repositories
{
    public class AppDataStorage<TEntity> : IStorage<TEntity>
    {
        private readonly HttpClient _httpClient;

        private TEntity _data;
        private readonly API _api;

        public AppDataStorage(HttpClient httpClient, API api)
        {
            _api = api;
            _httpClient = httpClient;
            FillAppData();
        }

        private void FillAppData()
        {
            var route = _api._apiKey[typeof(TEntity).Name];
            _data = Task.Run(async () => await _httpClient.ResponseDataPostAsync<TEntity>(route)).GetAwaiter().GetResult();
        }

        public TEntity GetData()
        {
            return _data ?? throw new NullReferenceException("Данные не заполнены!");
        }
    }
}
