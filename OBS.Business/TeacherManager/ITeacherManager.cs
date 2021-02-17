using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS.Entities.Tables;

namespace OBS.Business.TeacherManager
{
    public interface ITeacherManager
    {
        List<Teacher> Get();

        Teacher Create(Teacher teacher);

        Teacher GetCreateModel();

        List<SelectListItem> GetSelectList();
        Teacher Edit(Teacher teacher);
        Teacher Delete(Guid Id ,Teacher teacher);
    }
}
