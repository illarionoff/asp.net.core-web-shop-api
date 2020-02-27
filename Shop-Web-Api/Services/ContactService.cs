using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_Web_Api.Data;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbcontext _context;

        public ContactService(ApplicationDbcontext context)
        {
            _context = context;
        }


        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByUserIdAsync(string userID)
        {
            return await _context.Contacts.SingleOrDefaultAsync(contact => contact.UserID == userID);
        }

        public async Task<Contact> AddContactAsync(string userID, string address, string city)
        {
            var newContact = new Contact
            {
                Address = address,
                City = city,
                UserID = userID,
            };

            await _context.Contacts.AddAsync(newContact);
            var created = await _context.SaveChangesAsync();

            if (created <= 0) return null;

            return newContact;
        }

        public Task<bool> DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}