using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;

namespace Tests
{
    public class ATProject
    {   //333333
        //444444 add the unit test
        private GenInterface service;

        public ATProject()
        {
            service = Driver.getInstance();
        }

        public bool loginUser(string name, string pass)
        {
            return service.loginUser(name, pass);
        }

        
    }
}