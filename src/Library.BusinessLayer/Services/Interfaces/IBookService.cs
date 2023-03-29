using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync(CancellationToken cancellation);
        Task<BookDto> AddAsync(BookRequest book, CancellationToken cancellation);
        Task<BookDto> UpdateAsync(int id, BookRequest book, CancellationToken cancellation);
        Task<string> DeleteAsync(int id, CancellationToken cancellation);
    }
}
