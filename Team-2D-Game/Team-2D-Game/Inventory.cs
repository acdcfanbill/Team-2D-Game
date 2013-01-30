using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_2D_Game
{
    public class Inventory
    {
        public enum power { fire, ice, wind, shock };
        public static int MAX_POWER = 10;
        public static int currentMaxPower = 5;

        public InventoryLocation loc1;
        public InventoryLocation loc2;
        public InventoryLocation loc3;
        public InventoryLocation loc4;


        //right now, constructor makes all four locations with max 5
        public Inventory()
        {
            loc1 = new InventoryLocation(power.fire, currentMaxPower);
            loc2 = new InventoryLocation(power.ice, currentMaxPower);
            loc3 = new InventoryLocation(power.wind, currentMaxPower);
            loc4 = new InventoryLocation(power.shock, currentMaxPower);

            //give you 5 shots for each power
            loc1.addCharge(5);
            loc2.addCharge(5);
            loc3.addCharge(5);
            loc4.addCharge(5);
        }

        //pickup something, figure out what it is, and add it to our inventory.
        public void InventoryPickup(Inventory.power pickup, int amountPickedUp)
        {
            switch (pickup)
            {
                case power.fire:
                    loc1.addCharge(amountPickedUp);
                    break;
                case power.ice:
                    loc2.addCharge(amountPickedUp);
                    break;
                case power.wind:
                    loc3.addCharge(amountPickedUp);
                    break;
                case power.shock:
                    loc4.addCharge(amountPickedUp);
                    break;
                }
        }

        





        public void setCurrentMaxPower(int newMax)
        {
            currentMaxPower = newMax;
        }
    }

    /**
     * Helper class for inventory.  Power is set at instantiation, charge get be adjusted.
     */
    public class InventoryLocation
    {
        private Inventory.power locationPower;
        private int charge;
        private int maxPower;

        /**
         * Default constructor
         */
        public InventoryLocation(Inventory.power locationPower, int maxPower)
        {
            this.locationPower = locationPower;
            this.charge = 0;
            this.maxPower = maxPower;
        }

        /**
         * add charge to our current inventory, don't add more than our current max
         */
        public void addCharge(int chargeToAdd)
        {
            this.charge = this.charge + chargeToAdd;
            if (this.charge > this.maxPower)
                this.charge = this.maxPower;
        }

        /**
         * fire this power, if you have 0 charge, it returns false, otherwise it decriments charge
         * and returns true,
         */
        public bool firePower()
        {
            if(this.charge == 0)
                return false;
            this.charge--;
            return true;            
        }

        /**
         * get the int amount of charge for this locaiton
         */
        public int getCharge()
        {
            return this.charge;
        }
        
        /**
         * get the power
         */
        public Inventory.power getPower()
        {
            return this.locationPower;
        }

        /**
         * may need to change the max power, i.e. level up
         */
        public void setMaxPower(int newMaxPower)
        {
            this.maxPower = newMaxPower;
        }
    }
}
