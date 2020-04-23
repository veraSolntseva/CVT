using BL.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface IMainService
    {
        /// <summary>
        /// Получить список контактов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PersonDataModel>> GetPersonListAsync();

        /// <summary>
        /// Получить информацию о контакте
        /// </summary>
        /// <param name="personId">идентификатор контакта</param>
        /// <returns></returns>
        Task<PersonDataModel> GetPersonAsync(int personId);

        /// <summary>
        /// Редактировать контакт
        /// </summary>
        /// <param name="person">модель контакта</param>
        /// <returns></returns>
        Task EditPersonAsync(PersonDataModel person);

        /// <summary>
        /// Добавить контакт
        /// </summary>
        /// <param name="person">модель контакта</param>
        /// <returns></returns>
        Task AddPersonAsync(PersonDataModel person);

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="personId">идентификатор контакта</param>
        /// <returns></returns>
        Task DeletePersonAsync(int personId);
    }
}
