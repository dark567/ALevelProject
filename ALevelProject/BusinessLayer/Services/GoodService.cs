using AutoMapper;
using BuissnesLayer.DTO;
using BuissnesLayer.Interfaces;
using DataLayer.Entityes;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuissnesLayer.Services
{
    class GoodService: IGoodService
    {
        IUnitOfWork Database { get; set; }

        public GoodService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<DicClientsDTO> GetClients()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DicClient, DicClientsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DicClient>, List<DicClientsDTO>>(Database.DicClients.GetAll());
        }

        public DicClientsDTO GetClient(Guid? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id клиента");
            var client = Database.DicClients.Get(id.Value);
            if (client == null)
                throw new ValidationException("Клиент не найден");

            return new DicClientsDTO { ClientId = client.ClientId, Name = client.Name, Surname = client.Surname, Secname = client.Secname, Age = client.Age, Email = client.Email };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
