namespace MVC2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
                options.IdleTimeout = TimeSpan.FromDays(1));
            var app = builder.Build();
            app.Use(async (cont, nex) =>
            {
                //Console.WriteLine("middleware 1 -> forward");
                if (cont.Request.Cookies.ContainsKey("ReqNum"))
                {
                    //inc
                    int num = int.Parse(cont.Request.Cookies["ReqNum"]);
                    cont.Response.Cookies.Append("ReqNum", (++num).ToString());
                }
                else
                {
                    cont.Response.Cookies.Append("ReqNum", "1");
                }
                await nex();
                //Console.WriteLine("middleware 1 -> back");
            });
            //app.UseStaticFiles();
            app.UseSession();
            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}/{pnum?}");
           // app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}