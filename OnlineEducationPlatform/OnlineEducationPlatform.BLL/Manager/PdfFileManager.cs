using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public class PdfFileManager:IPdfFileManager
    {
        private readonly IPdfFileRepo _pdfFileRepo;
        private readonly IMapper _mapper;

        public PdfFileManager(IPdfFileRepo pdfFileRepo, IMapper mapper)
        {
            _pdfFileRepo = pdfFileRepo;
            _mapper = mapper;
        }
        public void Add(PdfFileAddDto pdfFileAddDto)
        {
            _pdfFileRepo.Add(_mapper.Map<PdfFile>(pdfFileAddDto));
            SaveChanges();
        }

        public void Delete(int id)
        {
            _pdfFileRepo.Delete(id);
            SaveChanges();
        }
        public IEnumerable<PdfFileReadDto> GetAll()
        {
            return _mapper.Map<List<PdfFileReadDto>>(_pdfFileRepo.GetAll());
        }

        public PdfFileReadDto GetById(int id)
        {
            return _mapper.Map<PdfFileReadDto>(_pdfFileRepo.GetById(id));
        }

        public void SaveChanges()
        {
            _pdfFileRepo.SaveChange();
        }

        public void Update(PdfFileUpdateDto pdfFileUpdateDto)
        {
            _mapper.Map<PdfFileUpdateDto, PdfFile>(pdfFileUpdateDto, _pdfFileRepo.GetById(pdfFileUpdateDto.Id));
            SaveChanges();
        }
    }
}

