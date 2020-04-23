using AutoMapper;
using BL.DataModels;
using BL.Services.Interfaces;
using DAL;
using DAL.DbObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class MainService : IMainService
    {
        private readonly CVTContext _context;
        private readonly IMapper _mapper;

        public MainService(CVTContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDataModel>> GetPersonListAsync()
        {
            List<PersonDataModel> personList = await _context.Persons.Include(o => o.Contacts).AsNoTracking()
                .Select(i => _mapper.Map<PersonDataModel>(i)).ToListAsync();

            return personList;
        }

        public async Task<PersonDataModel> GetPersonAsync(int personId)
        {
            Person person = await _context.Persons.Include(o => o.Contacts).AsNoTracking().FirstOrDefaultAsync(i => i.Id == personId);

            if (person is null)
                return null;

            return _mapper.Map<PersonDataModel>(person);
        }

        public async Task EditPersonAsync(PersonDataModel person)
        {
            if (!(_context.Persons.Include(o => o.Contacts).AsNoTracking().FirstOrDefault(i => i.Id == person.Id) is Person entity))
                throw new Exception("Контакт не найден.");

            Person newEntity = _mapper.Map<Person>(person);

            try
            {
                _context.Entry(newEntity).State = EntityState.Modified;

                List<int> listToEditContactId = newEntity.Contacts.Select(i => i.Id).ToList().Intersect(entity.Contacts.Select(e => e.Id).ToList()).ToList();

                List<int> listToAddContactId = newEntity.Contacts.Select(i => i.Id).ToList().Except(entity.Contacts.Select(e => e.Id).ToList()).ToList();

                List<int> listToRemoveContactId = entity.Contacts.Select(i => i.Id).ToList().Except(newEntity.Contacts.Select(e => e.Id).ToList()).ToList();


                foreach (var contact in newEntity.Contacts.Where(i => listToEditContactId.Contains(i.Id)))
                    _context.Entry(contact).State = EntityState.Modified;

                foreach(var contact in entity.Contacts.Where(i => listToRemoveContactId.Contains(i.Id)))
                {
                    ContactInfo contactEntity = await _context.Contacts.FindAsync(contact.Id);

                    _context.Contacts.Remove(contactEntity);
                }

                foreach (var contact in newEntity.Contacts.Where(i => listToAddContactId.Contains(i.Id)))
                {
                    contact.PersonId = entity.Id;

                    _context.Contacts.Add(contact);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddPersonAsync(PersonDataModel person)
        {
            Person entity = _mapper.Map<Person>(person);

            try
            {
                _context.Persons.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeletePersonAsync(int personId)
        {
            Person person = await _context.Persons.FindAsync(personId);

            if (person is null)
                throw new Exception("Контакт не найден.");

            _context.Persons.Remove(person);

            List<ContactInfo> personContactList = await _context.Contacts.Where(i => i.PersonId == personId).ToListAsync();

            _context.Contacts.RemoveRange(personContactList);

            await _context.SaveChangesAsync();
        }
    }
}
