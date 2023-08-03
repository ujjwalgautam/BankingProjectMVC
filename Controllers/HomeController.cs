using BankingProjectMVC.Areas.Identity.Data;
using BankingProjectMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;


namespace BankingProjectMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        
        

        public HomeController(ILogger<HomeController> logger,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Index(adminLogin admin)
        {
            using Context MyContext = new Context();
            var data = MyContext.AdminLogin.Where(c => c.UserName == admin.UserName).FirstOrDefault();
            if (data is null)
            {
                ModelState.AddModelError("IncorrectUserName", "The provided username is incorrect.");
                return View(admin);
            }
            else
            {
                if (data.Password != admin.Password)
                {
                    ModelState.AddModelError("IncorrectPassword", "The provided password is incorrect.");
                    return View(admin);
                }
                else
                {
                    return RedirectToAction("Menus");
                }
            }

        }
        public IActionResult Menus()
        {
            return View();
        }
 
        [HttpGet]
      
        public IActionResult AddNewUser()
        {
            var acc = 0;
            using Context myContext = new Context();
            var account = myContext.AccountDetails.ToList();
            if (account.LastOrDefault() != null)
            {
                acc = account.LastOrDefault().AccountNo + 1;
            }
            else
                acc = 1000000 + 1;
            ViewBag.accountNum = acc;
            return View();
        }
   

        [HttpPost]
        public IActionResult AddNewUser(AccountDetails account)
        {
            using Context myContext = new Context();
            myContext.AccountDetails.Add(new AccountDetails()
            {
                AccountNo = account.AccountNo,
                Name = account.Name,
                DOB = account.DOB,
                PhoneNumber = account.PhoneNumber,
                Address = account.Address,
                District = account.District,
                State = account.State,
                //Picture =account.Picture,
                Gender = account.Gender,
                MaritalStatus = account.MaritalStatus,
                MotherName = account.MotherName,
                FatherName = account.FatherName,
                Balance = account.Balance,
                Date = DateTime.Now,
            });
            myContext.SaveChanges();
            return RedirectToAction("AddNewUser");
        }

        [HttpGet]
        public IActionResult SearchUpdate()
        {
            return View();

        }

        [HttpPost]
        public IActionResult SearchUpdateByNumber(AccountDetails acc)
        {
            Context myContext = new();


            var accountNum = myContext.AccountDetails.Where(c => c.AccountNo == acc.AccountNo).FirstOrDefault();
            if (accountNum is null)
            {

                ModelState.AddModelError("InvalidAccount", "The provided Account Number is incorrect.");
                return View();
            }
            else
            {
                var num = accountNum.AccountNo;
                return RedirectToAction("Update", new { accountnum = num});
            }

        }


        [HttpPost]
        public IActionResult SearchUpdateByName(AccountDetails acc)
        {
            Context myContext = new();
            var accountName = myContext.AccountDetails.Where(c => c.Name == acc.Name).ToList();
            //var name = myContext.AccountDetails.Where(c => c.Name == acc.Name).Select(c => c.Name).FirstOrDefault();
            if (accountName.Count==0)
            {
                ModelState.AddModelError("InvalidAccountName", "The provided Account Name is incorrect.");
                return View();
            }
            else if (accountName.Count > 1)
            {
                string name = myContext.AccountDetails.Where(c => c.Name == acc.Name).Select(c => c.Name).FirstOrDefault();
                return RedirectToAction("MultipleAccountUpdate", new { accounts = name });

            }
            else
            {
                int num = myContext.AccountDetails.Where(c => c.Name == acc.Name).Select(c => c.AccountNo).FirstOrDefault();
                if(num==0)
                {
                    ModelState.AddModelError("InvalidAccountName", "The provided Account Name is incorrect.");
                    return View();
                }
                return RedirectToAction("Update", new { accountnum = num });
            }


        }

        public IActionResult MultipleAccountUpdate(string accounts)

        {
            Context myContext = new();
            var account = myContext.AccountDetails.Where(c => c.Name == accounts).ToList();
            return View(account);
        }
        

        [HttpGet]
        public IActionResult Update(int accountnum)
        {
            Context myContext=new();
            var account = myContext.AccountDetails.Where(c => c.AccountNo == accountnum).FirstOrDefault();
            if (account == null)
            {
                return RedirectToAction("Menus");
            }
            var a1 = new AccountDetails();

            a1.AccountNo = account.AccountNo;
            a1.Name = account.Name;
            a1.DOB = account.DOB;
            a1.PhoneNumber = account.PhoneNumber;
            a1.Address = account.Address;
            a1.District = account.District;
            a1.State = account.State;
            //a1.Picture =account.Picture;
            a1.Gender = account.Gender;
            a1.MaritalStatus = account.MaritalStatus;
            a1.MotherName = account.MotherName;
            a1.FatherName = account.FatherName;
            a1.Balance = account.Balance;
            a1.Date = account.Date;
           
                return View(a1);
            
        }

        [HttpPost]
        public IActionResult Update(AccountDetails account)
        {
            Context myContext = new();
            var a1 = myContext.AccountDetails.Where(c => c.AccountNo == account.AccountNo).FirstOrDefault();
            
            a1.AccountNo = account.AccountNo;
            a1.Name = account.Name;
            a1.DOB = account.DOB;
            a1.PhoneNumber = account.PhoneNumber;
            a1.Address = account.Address;
            a1.District = account.District;
            a1.State = account.State;
            //a1.Picture =account.Picture;
            a1.Gender = account.Gender;
            a1.MaritalStatus = account.MaritalStatus;
            a1.MotherName = account.MotherName;
            a1.FatherName = account.FatherName;
            a1.Balance = account.Balance;
            a1.Date = account.Date;
            myContext.SaveChanges();
            return RedirectToAction("SearchUpdate");

        }
        [HttpGet]
        public IActionResult UpdateByName(int AccountNo)
        {
            Context myContext = new();
            Console.WriteLine(AccountNo);
            var account = myContext.AccountDetails.Where(c => c.AccountNo == AccountNo).FirstOrDefault();
            if (account == null)
            {
                return RedirectToAction("Menus");
            }
            Console.WriteLine(account);
            var a1 = new AccountDetails();

            a1.AccountNo = account.AccountNo;
            a1.Name = account.Name;
            a1.DOB = account.DOB;
            Console.WriteLine(account.DOB);
            a1.PhoneNumber = account.PhoneNumber;
            a1.Address = account.Address;
            a1.District = account.District;
            a1.State = account.State;
            //a1.Picture =account.Picture;
            a1.Gender = account.Gender;
            a1.MaritalStatus = account.MaritalStatus;
            a1.MotherName = account.MotherName;
            a1.FatherName = account.FatherName;
            a1.Balance = account.Balance;
            a1.Date = account.Date;

            return View(a1);

        }

        [HttpPost]
        public IActionResult UpdateByName(AccountDetails account)
        {
            Context myContext = new();
            var a1 = myContext.AccountDetails.Where(c=>c.AccountNo==account.AccountNo).FirstOrDefault();

            a1.AccountNo = account.AccountNo;
            a1.Name = account.Name;
            a1.DOB = account.DOB;
            a1.PhoneNumber = account.PhoneNumber;
            a1.Address = account.Address;
            a1.District = account.District;
            a1.State = account.State;
            //a1.Picture =account.Picture;
            a1.Gender = account.Gender;
            a1.MaritalStatus = account.MaritalStatus;
            a1.MotherName = account.MotherName;
            a1.FatherName = account.FatherName;
            a1.Balance = account.Balance;
            a1.Date = account.Date;
            myContext.SaveChanges();
            return RedirectToAction("SearchUpdate");

        }

        public IActionResult ViewAllAccounts()
        {
            Context myContext = new();
            var accounts = myContext.AccountDetails.ToList();
            return View(accounts);
        }
   
        [HttpGet]
        public IActionResult CheckDeposit()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult CheckDeposit(Depositt data)
        {
            Context myContext = new Context();
            var acountNum = data.AccountNo;
            var AccountName = data.Name;
            var accounts = myContext.AccountDetails.Where(c => c.AccountNo == acountNum ).FirstOrDefault();
            if (accounts != null)
            {
                var accnum= myContext.AccountDetails.Where(c => c.AccountNo == acountNum ).Select(c=>c.AccountNo).FirstOrDefault();
                return RedirectToAction("Deposit", new { accountnum = accnum });
            }
            else
            {
                ModelState.AddModelError("InvalidAccountDetails", "The provided Account detail is incorrect.");
                return View(data);
            }
            
        }

        [HttpGet]
        public IActionResult Deposit(int accountnum)
        {
            Context myContext = new();
            var account=myContext.AccountDetails.Where(c => c.AccountNo == accountnum).FirstOrDefault();
            var dacc= new Depositt();
            dacc.AccountNo = account.AccountNo;
            dacc.Name = account.Name;
            return View(dacc);
        }
    
        [HttpPost]
        public IActionResult Deposit(Depositt data)
        {
            Context myContext = new Context();
            
            myContext.Deposit.Add(new Depositt()
            {
                Date = DateTime.Now,
                AccountNo = data.AccountNo,
                Name = data.Name,
                DipAmount = data.DipAmount,
                Depositor = data.Depositor,
                DepositorPhoneNo = data.DepositorPhoneNo,
            });

            var account = myContext.AccountDetails.Where(c => c.AccountNo == data.AccountNo).FirstOrDefault();
            if (account != null)
            {
                account.Balance += data.DipAmount;
            }
            myContext.SaveChanges();
            return RedirectToAction("Menus");
        }
 
        [HttpGet]
        public IActionResult CheckWithdraw()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckWithdraw(Debit data)
        {
            Context myContext = new Context();
            var acountNum = data.AccountNo;
            var AccountName = data.Name;
            var accounts = myContext.AccountDetails.Where(c => c.AccountNo == acountNum ).FirstOrDefault();
            if (accounts != null)
            {
                var accnum = myContext.AccountDetails.Where(c => c.AccountNo == acountNum).Select(c => c.AccountNo).FirstOrDefault();
                return RedirectToAction("Withdraw", new { accountnum = accnum });
            }
            else
            {
                ModelState.AddModelError("InvalidAccountDetails", "The provided Account detail is incorrect.");
                return View(data);
            }

        }
      
        [HttpGet]
        public IActionResult Withdraw(int accountnum)
        {
            Context myContext = new();
            var account = myContext.AccountDetails.Where(c => c.AccountNo == accountnum).FirstOrDefault();
            var dacc = new Debit();
            dacc.AccountNo = account.AccountNo;
            dacc.Name = account.Name;
            return View(dacc);
        }
  
        [HttpPost]
        public IActionResult Withdraw(Debit data)
        {
            Context myContext = new Context();
            var balance = myContext.AccountDetails.Where(c => c.AccountNo == data.AccountNo).Select(c=>c.Balance).FirstOrDefault();
            myContext.Debit.Add(new Debit()
            {
                Date = DateTime.Now,
                AccountNo = data.AccountNo,
                Name = data.Name,
                DebAmount = data.DebAmount,
                ChequeNo = data.ChequeNo,
                Withdrawer = data.Withdrawer,
                WithdrawerPhoneNo = data.WithdrawerPhoneNo,
            });
            if (data.DebAmount > balance)
            {
                ModelState.AddModelError("InsufficientAmount", "You do not have sufficient amount");
                return View(data);
            }
            if (data.DebAmount > 1000000)
            {
                ModelState.AddModelError("NotAllowedAmount", "You are not allowed to withdraw more tha 10 lakhs at a time");
                return View(data);
            }
            var account = myContext.AccountDetails.Where(c => c.AccountNo == data.AccountNo).FirstOrDefault();
            if (account != null)
            {
                account.Balance -= data.DebAmount;
            }
            myContext.SaveChanges();
            return RedirectToAction("Menus");
        }

        [HttpGet]
        public IActionResult CheckTransfer()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult CheckTransfer(Transferr data)
        {
            Context myContext = new Context();
            var acountNum = data.AccountNo;
            var AccountName = data.Name;
            var accounts = myContext.AccountDetails.Where(c => c.AccountNo == acountNum ).FirstOrDefault();
            if (accounts != null)
            {
                var ToacountNum = data.ToTransfer;
                var ToAccountName = data.ToName;
                var ToAccounts = myContext.AccountDetails.Where(c => c.AccountNo == ToacountNum ).FirstOrDefault();
                if(ToAccounts != null)
                {
                    return RedirectToAction("Transfer", new { accountnum = data.AccountNo, Toaccountnum=data.ToTransfer });
                }
                else
                {
                    ModelState.AddModelError("InvalidToAccountDetails", "The provided Receivers Account detail is incorrect.");
                    return View(data);
                }
                
            }
            else
            {
                ModelState.AddModelError("InvalidAccountDetails", "The provided Senders Account detail is incorrect.");
                return View(data);
            }

        }
     
        [HttpGet]
        public IActionResult Transfer(int accountnum, int Toaccountnum)
        {
            Context myContext = new();
            var name=myContext.AccountDetails.Where(c => c.AccountNo == accountnum).Select(c => c.Name).FirstOrDefault();
            var Toname=myContext.AccountDetails.Where(c => c.AccountNo == Toaccountnum).Select(c => c.Name).FirstOrDefault();
            var acc = new Transferr();
            acc.AccountNo = accountnum;
            acc.Name = name;
            acc.ToTransfer = Toaccountnum;
            acc.ToName = Toname;
            return View(acc);
        }
   
        [HttpPost]
        public IActionResult Transfer(Transferr data)
        {
            Context myContext = new Context();

            myContext.Transfer.Add(new Transferr()
            {
                Date = DateTime.Now,
                AccountNo = data.AccountNo,
                Name = data.Name,
                TAmountt=data.TAmountt,
                ToTransfer=data.ToTransfer,
                ToName=data.ToName,
                Depositor=data.Depositor,
                ChequeNumber=data.ChequeNumber,
                DepositorPhoneNo=data.DepositorPhoneNo,
            });
            var account = myContext.AccountDetails.Where(c => c.AccountNo == data.AccountNo).FirstOrDefault();
            if (data.TAmountt > account.Balance)
            {
                ModelState.AddModelError("InsufficientAmountt", "You do not have sufficient amount");

                return View(data);
            }
            
            if (account != null)
            {
                account.Balance -= data.TAmountt;
            }
            var Toaccount = myContext.AccountDetails.Where(c => c.AccountNo == data.ToTransfer).FirstOrDefault();
            

            if (Toaccount != null)
            {
                Toaccount.Balance += data.TAmountt;
            }
            myContext.SaveChanges();
            return RedirectToAction("Menus");
        }
     
        [HttpGet]
        public IActionResult CheckStatement()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult CheckStatement(int accountNumber)
        {
            Context myContext = new();
            var acc=myContext.AccountDetails.Where(c=>c.AccountNo== accountNumber).FirstOrDefault();    
            if(acc != null)
            {
                return RedirectToAction("Statement", new { accountNum = accountNumber });
            }
            else
            {
                ModelState.AddModelError("InvalidAccount", "No account found with given data");
                return View(accountNumber);
            }
            
        }
     
        public IActionResult Statement(int accountNum)
        {
            Context myContext = new();
            List<Statement> statement = new();
            ViewBag.balance = myContext.AccountDetails.Where(c => c.AccountNo == accountNum).Select(c => c.Balance).FirstOrDefault();
            var deposits = myContext.Deposit.Where(c => c.AccountNo == accountNum).ToList();
            
            if (deposits.Any())
            {
                foreach(Depositt d in deposits)
                {
                    var s1 = new Statement();
                    s1.SenderAccountNumber = d.AccountNo.ToString();
                    s1.SenderName = "Self";
                    s1.ReceiverAccountNumber = "Self";
                    s1.ReceiverName = "Self";
                    s1.Amount = d.DipAmount;
                    s1.Mode = "Deposit";
                    s1.Status = true;
                    s1.Date = d.Date;
                    statement.Add(s1);
                }
           
            }
            var withdraw = myContext.Debit.Where(c => c.AccountNo == accountNum).ToList();
            if (withdraw.Any())
            {
                foreach (Debit d in withdraw)
                {
                    var s1 = new Statement();
                    s1.SenderAccountNumber = d.AccountNo.ToString();
                    s1.SenderName = "Self";
                    s1.ReceiverAccountNumber = "Self";
                    s1.ReceiverName = "Self";
                    s1.Amount = d.DebAmount;
                    s1.Mode = "Withdraw";
                    s1.Status = false;
                    s1.Date = d.Date;
                    statement.Add(s1);
                }
            }
            var send = myContext.Transfer.Where(c => c.AccountNo == accountNum).ToList();
            if (send.Any())
            {
                foreach (Transferr d in send)
                {
                    var s1 = new Statement();
                    s1.SenderAccountNumber = d.AccountNo.ToString();
                    s1.SenderName = d.Name;
                    s1.ReceiverAccountNumber = d.ToTransfer.ToString();
                    s1.ReceiverName = d.ToName;
                    s1.Amount = d.TAmountt;
                    s1.Mode = "Sent";
                    s1.Status = false;
                    s1.Date = d.Date;
                    statement.Add(s1);
                }
            }
            var receive = myContext.Transfer.Where(c => c.ToTransfer == accountNum).ToList();
            if (receive.Any())
            {
                foreach (Transferr d in receive)
                {
                    var s1 = new Statement();
                    s1.SenderAccountNumber =  d.AccountNo.ToString();
                    s1.SenderName = d.Name;
                    s1.ReceiverAccountNumber = d.ToTransfer.ToString();
                    s1.ReceiverName = d.ToName;
                    s1.Amount = d.TAmountt;
                    s1.Mode = "Received";
                    s1.Status = true;
                    s1.Date = d.Date;
                    statement.Add(s1);
                }
                
            }
            var orderedStatement = statement.OrderByDescending(s => s.Date).ToList();
            return View(orderedStatement);
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}