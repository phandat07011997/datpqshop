using DatPQShop.Model.Models;
using DatPQShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatPQShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.ID = productCategoryVm.ID;

            productCategory.Name = productCategoryVm.Name;

            productCategory.Alias = productCategoryVm.Alias;

            productCategory.Description = productCategoryVm.Description;

            productCategory.ParentID = productCategoryVm.ParentID;

            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;

            productCategory.Image = productCategoryVm.Image;

            productCategory.HomeFlag = productCategoryVm.HomeFlag;

            productCategory.CreatedDate = productCategoryVm.CreatedDate;

            productCategory.CreatedBy = productCategoryVm.CreatedBy;

            productCategory.UpdateDate = productCategoryVm.UpdateDate;

            productCategory.UpdateBy = productCategoryVm.UpdateBy;

            productCategory.MetaKeyword = productCategoryVm.MetaKeyword;

            productCategory.MetaDescription = productCategoryVm.MetaDescription;

            productCategory.Status = productCategoryVm.Status;

        }
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;

            postCategory.Name = postCategoryVm.Name;

            postCategory.Alias = postCategoryVm.Alias;

            postCategory.Description = postCategoryVm.Description;

            postCategory.ParentID = postCategoryVm.ParentID;

            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;

            postCategory.Image = postCategoryVm.Image;

            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;

            postCategory.CreatedBy = postCategoryVm.CreatedBy;

            postCategory.UpdateDate = postCategoryVm.UpdateDate;

            postCategory.UpdateBy = postCategoryVm.UpdateBy;

            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;

            postCategory.MetaDescription = postCategoryVm.MetaDescription;

            postCategory.Status = postCategoryVm.Status;

        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.Description = postVm.Description;
            post.ID = postVm.ID;
            post.HomeFlag = postVm.HomeFlag;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.ViewCount = postVm.ViewCount;
            post.HotFlag = postVm.HotFlag;
            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdateDate = postVm.UpdateDate;
            post.UpdateBy = postVm.UpdateBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;

        }
    }
}