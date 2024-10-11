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
    public class VedioManager:IVedioManager
    {
        private readonly IVedioRepo _vedioRepo;
        private readonly IMapper _mapper;

        public VedioManager(IVedioRepo vedioRepo, IMapper mapper)
        {
            _vedioRepo = vedioRepo;
            _mapper = mapper;
        }
        public void Add(VedioAddDto vedioAddDto)
        {
            _vedioRepo.Add(_mapper.Map<Video>(vedioAddDto));
            SaveChanges();
        }

        public void Delete(int id)
        {
            _vedioRepo.Delete(id);
            SaveChanges();
        }
        public IEnumerable<VedioReadDto> GetAll()
        {
            return _mapper.Map<List<VedioReadDto>>(_vedioRepo.GetAll());
        }

        public VedioReadDto GetById(int id)
        {
            return _mapper.Map<VedioReadDto>(_vedioRepo.GetById(id));
        }

        public void SaveChanges()
        {
            _vedioRepo.SaveChange();
        }

        public void Update(VedioUpdateDto vedioUpdateDto)
        {
            _mapper.Map<VedioUpdateDto, Video>(vedioUpdateDto, _vedioRepo.GetById(vedioUpdateDto.Id));
            SaveChanges();
        }
    }
}
