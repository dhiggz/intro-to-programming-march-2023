namespace Banking.Domain
{
    public class BankAccount
    {
        private decimal _balance = 5000;
        public void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
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