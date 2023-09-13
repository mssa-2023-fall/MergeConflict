using CustomerLogin;

var ourDB = new BadDatabase();

ourDB.AddCustomer("EXemail", "EXname", "EXpassword", "EXcreditcard");

var ourCustomer = ourDB.DB["EXemail"];

Console.WriteLine($"{ourCustomer.Name}\n{ourCustomer.Email}\n{ourCustomer.Salt}\n{ourCustomer.EncryptedCreditCard}");

