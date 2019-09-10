using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class UserWrapperViewModel
    {
        public List<UserListViewModel> UserList { get; set; }
        public PagingData PagingData { get; set; }
        public int TotalCount { get; set; }
    }

    public class UserListViewModel
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string CreatedDate { get; set; }
    }
}
