using DVLD_Buisness.Global_Classes;
using DVLD_Buisness;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DVLD.Global_Classes;
using DVLD.Global.Classes;

namespace Hotel.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("GetAllEmployees", Name = "GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<EmployeesListDTO>> GetAllEmployees()
        {
            List<EmployeesListDTO> EmployeesList = clsEmployee.GetAllEmployees();

            if (EmployeesList.Count == 0)
                return NotFound("Not  Employees Found !");

            return Ok(EmployeesList);
        }

        [HttpGet("IsEmployeeExistByID/{EmployeeID}", Name = "IsEmployeeExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsEmployeeExistByID(int EmployeeID)
        {
            if (EmployeeID < 1)
                return BadRequest("Not Accepted ID : " + EmployeeID);



            return Ok(clsEmployee.IsEmployeeExist(EmployeeID));
        }


        [HttpGet("IsEmployeeExistByUserName/{UserName}", Name = "IsEmployeeExistByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsEmployeeExistByUserName(string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
                return BadRequest("Not Accepted UserName : " + UserName);



            return Ok(clsEmployee.IsEmployeeExist(UserName));
        }

        [HttpGet("IsEmployeeExistForNationalNo/{NationalNo}", Name = "IsEmployeeExistForNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsEmployeeExistForNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo))
                return BadRequest("Not Accepted Employee National No : " + NationalNo);



            return Ok(clsEmployee.IsEmployeeExistForNationalNo(NationalNo));
        }


        [HttpGet("IsEmployeeExistForPersonID/{PersonID}", Name = "IsEmployeeExistForPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsEmployeeExistForPersonID(int PersonID)
        {
            if (PersonID<1)
                return BadRequest("Not Accepted ID : " + PersonID);



            return Ok(clsEmployee.IsEmployeeExistForPersonID(PersonID));
        }


        [HttpDelete("DeleteEmployee/{EmployeeID}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteEmployee(int EmployeeID)
        {
            if (EmployeeID < 1)
                return BadRequest("Not Accepted ID : " + EmployeeID);

            clsEmployee Employee = clsEmployee.FindByEmployeeID(EmployeeID);

            if (!clsEmployee.IsEmployeeExist(EmployeeID))
                return NotFound("Employee with id : " + EmployeeID + " Not Found !");

            if (!clsEmployee.DeleteEmployee(EmployeeID))
                return StatusCode(500, "Error delete Employee");


            return Ok("Employee with id : " + EmployeeID + " has been deleted");


        }


        [HttpGet("GetEmployeeByID/{EmployeeID}", Name = "GetEmployeeByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AllEmployeeInfoDTO> GetEmployeeByID(int EmployeeID)
        {
            if (EmployeeID < 1)
                return BadRequest("Not Accepted ID : " + EmployeeID);

            clsEmployee Employee = clsEmployee.FindByEmployeeID(EmployeeID);

            if (Employee == null)
                return NotFound("Employee With ID : " + EmployeeID + " Not Found !");

            return Ok(Employee.allEmployeeInfoDTO);

        }


        [HttpGet("GetEmployeeByUserNameAndPassword/{UserName},{Password}", Name = "GetEmployeeByUserNameAndPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AllEmployeeInfoDTO> GetEmployeeByUserNameAndPassword(string UserName,string Password)
        {
            if (string.IsNullOrEmpty(UserName)|| string.IsNullOrEmpty(Password))
                return BadRequest("Not Accept UserName  : "+UserName+" And Password : "+Password);

            clsEmployee Employee = clsEmployee.FindByUserNameAndPassword(UserName,Password);

            if (Employee == null)
                return NotFound("Employee With UserName : " + UserName + "And Password : "+Password+" Not Found !");

            return Ok(Employee.allEmployeeInfoDTO);

        }

        [HttpGet("GetEmployeeByNationalNo/{NationalNo}", Name = "GetEmployeeByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AllEmployeeInfoDTO> GetEmployeeByNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo))
                return BadRequest("Not Accepted NationalNo : " + NationalNo);

            clsEmployee Employee = clsEmployee.FindByNationalNo(NationalNo);

            if (Employee == null)
                return NotFound("Employee With NationalNo : " + NationalNo + " Not Found !");

            return Ok(Employee.allEmployeeInfoDTO);

        }

        [HttpPost("AddEmployee", Name = "AddEmployee")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AllEmployeeInfoDTO> AddEmployee([FromForm] AllEmployeeInfoDTO allEmployeeInfoDTO,IFormFile ImageFile,
            clsPerson.enGender Gender)
        {
            if (allEmployeeInfoDTO == null ||string.IsNullOrEmpty(allEmployeeInfoDTO.UserName) || string.IsNullOrEmpty(allEmployeeInfoDTO.NationalNo) ||
                string.IsNullOrEmpty(allEmployeeInfoDTO.FirstName) || string.IsNullOrEmpty(allEmployeeInfoDTO.LastName) ||
                string.IsNullOrEmpty(allEmployeeInfoDTO.Phone) || !clsValidation.ValidateInteger(Convert.ToString(allEmployeeInfoDTO.Phone))
                || allEmployeeInfoDTO.NationalityCountryID < 1 || string.IsNullOrEmpty(allEmployeeInfoDTO.Password)
                || !clsValidation.IsNumber(Convert.ToString(allEmployeeInfoDTO.Salary))
                
                )
                return BadRequest("Invalid Employee Data !");


            if (!string.IsNullOrEmpty(allEmployeeInfoDTO.Email) && !clsValidation.ValidateEmail(allEmployeeInfoDTO.Email))
                return BadRequest("Email " + allEmployeeInfoDTO.Email + " Not Valide");

            if (clsEmployee.IsEmployeeExist(allEmployeeInfoDTO.UserName))
                return BadRequest("UserName :" + allEmployeeInfoDTO.UserName + " Already exist");

            if (clsEmployee.IsEmployeeExistForNationalNo(allEmployeeInfoDTO.NationalNo))
                return BadRequest("National No : " + allEmployeeInfoDTO.NationalNo + " Already exist");

            if (ImageFile == null || ImageFile.Length == 0)
                return BadRequest("No image file provided.");

            allEmployeeInfoDTO.Password = clsCryptography.ComputeHash(allEmployeeInfoDTO.Password);


            if (clsCountry.Find(allEmployeeInfoDTO.NationalityCountryID) == null)
                return BadRequest("Country With id " + allEmployeeInfoDTO.NationalityCountryID + " Not Found !");

            allEmployeeInfoDTO.Image = clsUtil.ConvertImageToByteArray( ImageFile);

            clsEmployee Employee = new clsEmployee(new EmployeeDTO(-1,-1,allEmployeeInfoDTO.HireDate,null,allEmployeeInfoDTO.UserName,
                allEmployeeInfoDTO.Password, allEmployeeInfoDTO.IsActive, allEmployeeInfoDTO.Image, allEmployeeInfoDTO.Salary),
                new PersonDTO(-1, allEmployeeInfoDTO.NationalNo, (byte)Gender, allEmployeeInfoDTO.FirstName, allEmployeeInfoDTO.MidlleName,
                allEmployeeInfoDTO.LastName, allEmployeeInfoDTO.Email, allEmployeeInfoDTO.Phone, allEmployeeInfoDTO.Address,
                allEmployeeInfoDTO.DateOfBirth, allEmployeeInfoDTO.NationalityCountryID));

            if (!Employee.Save())
                return StatusCode(500, "Error Add Employee");

            allEmployeeInfoDTO.EmployeeID = Employee.EmployeeID;
            allEmployeeInfoDTO.PersonID = Employee.PersonID;

            return CreatedAtRoute("GetEmployeeByID", new { EmployeeID = allEmployeeInfoDTO.EmployeeID }, allEmployeeInfoDTO);


        }


        [HttpGet("GetImage/{EmployeeID}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult GetEmployeeImage(int EmployeeID)
        {
            if (EmployeeID < 1)
                return BadRequest("Not Accepted ID : " + EmployeeID);

            clsEmployee Employee = clsEmployee.FindByEmployeeID(EmployeeID);

            if (Employee == null)
                return NotFound("Employee With ID : " + EmployeeID + " Not Found !");

           

            var ImageBytes =(Employee.Image);
            var MimeType = "image/jpg";




            return File(ImageBytes,MimeType);
        }

        private string GetMimeType(string FilePath)
        {
            var Extension = Path.GetExtension(FilePath).ToLowerInvariant();

            return Extension switch
            {
                ".jpg" => "image/jpg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };
        }


        [HttpPut("UpdateEmployee/{EmployeeID}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AllEmployeeInfoDTO> UpdateEmployee(int EmployeeID, [FromForm] AllEmployeeInfoDTO allEmployeeInfoDTO,
            IFormFile ImageFile,clsPerson.enGender gender)
        {
            if (allEmployeeInfoDTO == null||EmployeeID<1 || string.IsNullOrEmpty(allEmployeeInfoDTO.UserName) || string.IsNullOrEmpty(allEmployeeInfoDTO.NationalNo) ||
                string.IsNullOrEmpty(allEmployeeInfoDTO.FirstName) || string.IsNullOrEmpty(allEmployeeInfoDTO.LastName) ||
                string.IsNullOrEmpty(allEmployeeInfoDTO.Phone) || !clsValidation.ValidateInteger(Convert.ToString(allEmployeeInfoDTO.Phone))
                || allEmployeeInfoDTO.NationalityCountryID < 1 || string.IsNullOrEmpty(allEmployeeInfoDTO.Password)
                || !clsValidation.IsNumber(Convert.ToString(allEmployeeInfoDTO.Salary))

                )
                return BadRequest("Invalid Employee Data !");
            clsEmployee Employee = clsEmployee.FindByEmployeeID(EmployeeID);

            if (Employee == null)
                return NotFound("Employee With ID : " + EmployeeID + " Not Found !");


            if (Employee.UserName != allEmployeeInfoDTO.UserName && clsEmployee.IsEmployeeExist(allEmployeeInfoDTO.UserName))
                return BadRequest("UserName :"+allEmployeeInfoDTO.UserName+" Already exist");


            if (Employee.Email != allEmployeeInfoDTO.Email && !string.IsNullOrEmpty(allEmployeeInfoDTO.Email) && !clsValidation.ValidateEmail(allEmployeeInfoDTO.Email))
                return BadRequest("Email " + allEmployeeInfoDTO.Email + " Not Valide");



            if (Employee.NationalNo != allEmployeeInfoDTO.NationalNo && clsEmployee.IsEmployeeExistForNationalNo(allEmployeeInfoDTO.NationalNo))
                return BadRequest("National No : " + allEmployeeInfoDTO.NationalNo + " Already exist");


            


            if (Employee.NationalityCountryID != allEmployeeInfoDTO.NationalityCountryID && clsCountry.Find(allEmployeeInfoDTO.NationalityCountryID) == null)
                return BadRequest("Country With id " + allEmployeeInfoDTO.NationalityCountryID + " Not Found !");


            if (ImageFile != null || ImageFile.Length != 0)
            {
                allEmployeeInfoDTO.Image = clsUtil.ConvertImageToByteArray(ImageFile);
            }

            string PasswordHashed = clsCryptography.ComputeHash(allEmployeeInfoDTO.Password);
            if(Employee.Password!= PasswordHashed)

               allEmployeeInfoDTO.Password= clsCryptography.ComputeHash(allEmployeeInfoDTO.Password);





            Employee.HireDate = allEmployeeInfoDTO.HireDate;
            Employee.EndDate = allEmployeeInfoDTO.EndDate;
            Employee.UserName = allEmployeeInfoDTO.UserName;
            Employee.Password = allEmployeeInfoDTO.Password;
            Employee.IsActive = allEmployeeInfoDTO.IsActive;
            Employee.Image = allEmployeeInfoDTO.Image;
            Employee.Salary = allEmployeeInfoDTO.Salary;

            Employee.NationalNo = allEmployeeInfoDTO.NationalNo;
            Employee.Gender = (byte)gender;
            Employee.FirstName = allEmployeeInfoDTO.FirstName;
            Employee.MidlleName = allEmployeeInfoDTO.MidlleName;
            Employee.LastName = allEmployeeInfoDTO.LastName;
            Employee.Email = allEmployeeInfoDTO.Email;
            Employee.Phone = allEmployeeInfoDTO.Phone;
            Employee.Address = allEmployeeInfoDTO.Address;
            Employee.NationalityCountryID = allEmployeeInfoDTO.NationalityCountryID;
            Employee.DateOfBirth = allEmployeeInfoDTO.DateOfBirth;

            if (!Employee.Save())
                return StatusCode(500, "Error Updating Employee");



            return Ok(Employee.allEmployeeInfoDTO);

        }



    }
}
