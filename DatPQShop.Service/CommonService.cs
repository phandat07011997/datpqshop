using DatPQShop.Common;
using DatPQShop.Data.Infrastructure;
using DatPQShop.Data.Repositories;
using DatPQShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPQShop.Service
{
    public interface ICommonService
    {
        IEnumerable<Slide> GetSlides();
        Footer GetFooter();
    }
    public class CommonService : ICommonService
    {
        ISlideRepository _slideRepository;
        IFooterRepository _footerRepository;
        IUnitOfWork _unitOfWork;
        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
        }
        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterID);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status == true);
        }
    }
}
