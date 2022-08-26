//open program.cs file and update your ConfigureServices method like this. 
 
 public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            //this line tells which interface is implemented by which class.
            services.AddSingleton<IEmployee, EmployeeRepository>();
        }
