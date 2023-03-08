namespace Banking.Domain
{
    public class BankAccount
    {
        private decimal _balance = 5000;
        public virtual void Deposit(decimal amountToDeposit)
        {
            //decimal bonusToAdd = _bonusCaclculator.CalculateBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit;// + bonusToAdd;
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