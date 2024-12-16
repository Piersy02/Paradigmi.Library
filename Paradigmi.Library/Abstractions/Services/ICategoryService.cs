using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        bool AddCategory(string nome); //aggiunge una nuova categoria
        bool DeleteCategory(string nome); //elimina una categoria
    }
}
