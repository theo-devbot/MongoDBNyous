using MongoDBNyous.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBNyous.Interfaces
{
    interface IEventoRepository
    {
        List<EventoDomain> Listar();

        EventoDomain BuscarPorId(string id);

        void Adicionar(EventoDomain evento);

        void Atualizar(string id, EventoDomain evento);

        void Remover(string id);
    }
}