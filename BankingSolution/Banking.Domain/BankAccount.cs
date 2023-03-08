namespace Banking.Domain
{

    public enum BankAccountType { Standard, Gold }
    public class BankAccount
    {
        public BankAccountType AccountType = BankAccountType.Standard;
        private decimal _balance = 5000;
        public void Deposit(decimal amountToDeposit)
        {
            // this is an if statement - we have an opportunity for a bug here
            var bonus = AccountType == BankAccountType.Gold ? amountToDeposit * 0.10M : 0;
            _balance += amountToDeposit + bonus;
        }

        public decimal GetBalance()
        {
            return _balance; // JFHCI (Slimed!) - Just freaking hard code it... It's okay to be trash here (to start)
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }else
            {
                _balance -= amountToWithdraw;
            }
        }
    }
}