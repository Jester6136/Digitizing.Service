using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface IWebsiteTagRepository
    {
        bool Create(WebsiteTagModel model);
        bool Update(WebsiteTagModel model);
        List<WebsiteTagModel> Search(int pageIndex, int pageSize, char lang, out long total, string tag_name);
        WebsiteTagModel GetById(Guid? id);
        List<WebsiteTagModel> Delete(string json_list_id, Guid updated_by);
        List<DropdownOptionModel> GetListDropdown(char lang);

    }
}