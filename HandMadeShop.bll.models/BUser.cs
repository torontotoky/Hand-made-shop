﻿namespace HandMadeShop.bll.models
{
    public class BUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}