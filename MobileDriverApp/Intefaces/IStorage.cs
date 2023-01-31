using Microsoft.Extensions.Options;
using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Intefaces
{
    public interface IStorage<TEntity>
    {
        public TEntity GetData();
    }
}
