using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PhoneBookRecordsController : Controller
    {
        private PhoneBookContext _context;

        public PhoneBookRecordsController(PhoneBookContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var phonebookrecords = _context.PhoneBookRecords.Select(i => new {
                i.ID,
                i.FullName,
                i.AreaID,
                i.Address,
                i.Phone
            });

            return Json(await DataSourceLoader.LoadAsync(phonebookrecords, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new PhoneBookRecord();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.PhoneBookRecords.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.ID });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.PhoneBookRecords.FirstOrDefaultAsync(item => item.ID == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.PhoneBookRecords.FirstOrDefaultAsync(item => item.ID == key);

            _context.PhoneBookRecords.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> AreasLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Areas
                         orderby i.Name
                         select new {
                             Value = i.ID,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(PhoneBookRecord model, IDictionary values) {
            string ID = nameof(PhoneBookRecord.ID);
            string FULL_NAME = nameof(PhoneBookRecord.FullName);
            string AREA = nameof(PhoneBookRecord.AreaID);
            string ADDRESS = nameof(PhoneBookRecord.Address);
            string PHONE = nameof(PhoneBookRecord.Phone);

            if(values.Contains(ID)) 
            {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(FULL_NAME)) 
            {
                model.FullName = Convert.ToString(values[FULL_NAME]);
            }

            if (values.Contains(AREA))
            {
                model.AreaID = Convert.ToInt32(values[AREA]);
            }

            if (values.Contains(ADDRESS)) 
            {
                model.Address = Convert.ToString(values[ADDRESS]);
            }

            if(values.Contains(PHONE)) 
            {
                model.Phone = Convert.ToString(values[PHONE]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}