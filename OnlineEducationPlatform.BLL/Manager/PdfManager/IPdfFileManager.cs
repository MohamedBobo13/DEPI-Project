using OnlineEducationPlatform.BLL.ViewModels.PdfVm;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface IPdfFileManager
    {
        Task AddAsync(PdfFileAddVm pdfFileAddDto);
        Task<IEnumerable<PdfFileReadVm>> GetAllAsync();
        Task<PdfFileReadVm> GetByIdAsync(int id);
        Task<PdfFileUpdateVm> UpdateAsync(PdfFileUpdateVm pdfFileUpdateDto);
        Task<bool> DeleteAsync(int id);

    }
}
