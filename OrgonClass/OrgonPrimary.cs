using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace OrgonClass
{
    //make a class named ORGONPRIMARY static and shared
    public static class OrgonPrimary
    {
        

        public static Map map = null;
        

        public static Map GetMap()
        {
            return map;
        }

        public static void DeleteMap()
        {
         
            map = null;
        }

        public static Map GenerateMap(int width, int height, int islands, int islandsSize)
        {
            

            map = new Map(width, height, islands, islandsSize);
            return map;


        }

      
        
        

        
    }

}