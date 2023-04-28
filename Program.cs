using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;
using System.Data;

namespace RECIPE
{
    class Program
    {

        struct RecipeNeeds
        {
            public float Number_Of_Ingridients;
            public float Number_Of_Steps;
            public float Unit_Of_Measurement;
            public float total;
            public string RecipeID;
            public string Ingrdient_Name;
            public string Ingridient_Quantity;
            public string Recipe_Steps;
        };

        //The Main Method of the Program

        static void Main(string[] args)
        {

            const int Num = 4;

            try
            {
                RecipeNeeds[] recipe = new RecipeNeeds[Num];
                int Option;
                string Authenticate;
                int Compute_Recipe = 0;


                do
                {
                    SeeOptions();
                    Console.WriteLine("May you enter a choice from the options listed" + "\n");
                    Option = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (Option)
                    {

                        case 1:
                            add(recipe, ref Compute_Recipe);
                            break;

                        case 2:
                            View(recipe, ref Compute_Recipe);
                            break;


                        case 3:
                            Edit(recipe, ref Compute_Recipe);
                            break;

                        case 4:
                            Clear(recipe, ref Compute_Recipe);
                            break;



                        default:
                            Console.WriteLine("Please enter a valid Option" + "\n");
                            break;

                    }

                    Console.Write("Type agree or Agree to proceed");
                    Authenticate = Console.ReadLine().ToString();
                    Console.Clear();
                }

                while (Authenticate == "agree" || Authenticate == "Agree");
            }

            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid Option" + "\n");

            }
            Console.ReadLine();

        }

        static void SeeOptions()
        {
            Console.WriteLine("1- Enter Recipe");
            Console.WriteLine("2- View Your Recipe");
            Console.WriteLine("3- Edit your Recipe");
            Console.WriteLine("4- Delete your Recipe");
        }

        //This is to add a method that allows the user to enter their desired recipe

        static void add(RecipeNeeds[] recipe, ref int Compute_Recipe)
        {

        Again:

            Console.WriteLine("This to add your desired Recipe" + "\n");
            Console.WriteLine("Please the recipe ID");
            recipe[Compute_Recipe].RecipeID = Console.ReadLine().ToString();

            if (Search(recipe, recipe[Compute_Recipe].Number_Of_Ingridients, Compute_Recipe) != -1)
            {
                Console.Clear();
                Console.WriteLine("You cannot enter that amount of Ingridients" + "\n");
                goto Again;

            }

            Console.WriteLine("Please the number of Ingridients in this recipe");
            recipe[Compute_Recipe].Number_Of_Ingridients = int.Parse(Console.ReadLine().ToString());
            Console.Write("Please enter the Ingridients needed for this recipe. Press Enter once done");
            recipe[Compute_Recipe].Ingrdient_Name = Console.ReadLine().ToString();
            Console.Write("Please enter the Quantity of each Ingridient you have entered (Example: 2 Apples). Press Enter once done.");
            recipe[Compute_Recipe].Ingridient_Quantity = Console.ReadLine().ToString();
            Console.Write("Please enter the Unit Of Measaurement for each ingridient (Example 100 grams). Press Enter once done.");
            recipe[Compute_Recipe].Unit_Of_Measurement = int.Parse(Console.ReadLine().ToString());
            Console.Write("Please enter the Number of Steps for this recipe.Press Enter once done");
            recipe[Compute_Recipe].Number_Of_Steps = int.Parse(Console.ReadLine().ToString());
            Console.Write("Please the steps for this recipe.Press Enter once done.");
            recipe[Compute_Recipe].Recipe_Steps = Console.ReadLine().ToString();

            recipe[Compute_Recipe].total = float.Parse(recipe[Compute_Recipe].Number_Of_Ingridients + recipe[Compute_Recipe].Ingrdient_Name + recipe[Compute_Recipe].Ingridient_Quantity + recipe[Compute_Recipe].Unit_Of_Measurement + recipe[Compute_Recipe].Number_Of_Steps + recipe[Compute_Recipe].Recipe_Steps);
            ++Compute_Recipe;

        }

        private static int Search(RecipeNeeds[] recipe, float number_Of_Ingridients, int compute_Recipe)
        {
            throw new NotImplementedException();
        }

        // A sperate method has been created in order to allow the user to view the recipe
        static void View(RecipeNeeds[] recipe, ref int Compute_Recipe)
        {
            int x = 0;

            Console.WriteLine();
            Console.WriteLine(" {0, -5} \t {1, -20} {2, -10} {3, -10} {4, -10} {5, -9} {6, -11}{7, -15}{8, -5} (Pile Index)", "0", "1", "2", "3", "4", "5", "6", "7");
            Console.WriteLine();
            Console.WriteLine(" {0, -5} \t {1, -15} \t {2, -5} \t {3, -10} {4, -10} {5,-5} {6, -5} \t {7, -5} \t {8, -5}", "Recipe ID", "Number of Ingridients", "Ingridient Names", "Ingrient Quantities", "Ingrient Unit of Measurement", "Number of Steps", "Description of Steps");

            while (x < Compute_Recipe)
            {

                if (recipe[x].RecipeID != null)
                {
                    Console.Write(" {0, -5} \t {1,-20} {2,-10}", recipe[x].RecipeID, recipe[x].Number_Of_Ingridients, recipe[x].Ingrdient_Name);
                    Console.Write(" {0, -9} {1, -9} {2,9}", recipe[x].Ingridient_Quantity, recipe[x].Unit_Of_Measurement, recipe[x].Number_Of_Steps);
                    Console.Write(" {0, -12} {1, -15} { 2, -10}", recipe[x].Recipe_Steps, recipe[x].total);
                    Console.WriteLine("\n");
                }

                x = x + 1;
            }
        }

        //A separate method has been created to allow the user to edit or scale the recipe by factor
        static void Edit(RecipeNeeds[] recipe, ref int Compute_Recipe)

        {
            int pile_index;
            String I;

            Console.Write("Enter the Recipe: ");
            I = Console.ReadLine();

            Console.WriteLine("What would you like to edit within the Recipe?" + "\n");
            Console.WriteLine("1- The Number of Ingridients");
            Console.WriteLine("2- The Names of the Ingridients");
            Console.WriteLine("3- The Quantity of the Ingridients");
            Console.WriteLine("4- The Unit of Measurement of the Ingridients");
            Console.WriteLine("5- The Number of Steps within the Recipe");
            Console.WriteLine("6- The Description of the Steps");
            Console.WriteLine("\n");

            pile_index = int.Parse(Console.ReadLine());

            int index = Search(recipe, I.ToString(), ref Compute_Recipe);

            if ((index != -1) && (Compute_Recipe != 0))
            {

                if (pile_index == 1)
                {
                    Console.Write("Enter the number of Ingridients you would like to edit");
                    recipe[index].Number_Of_Ingridients = int.Parse(Console.ReadLine().ToString());

                }

                else if (pile_index == 2)
                {
                    Console.Write("Enter the names of Ingridients you would like to edit");
                    recipe[index].Ingrdient_Name = Console.ReadLine().ToString();

                }

                else if (pile_index == 3)
                {
                    Console.Write("Enter the Quantity of the Ingridients you would like to edit");
                    recipe[index].Ingridient_Quantity = Console.ReadLine().ToString();

                }

                else if (pile_index == 4)
                {
                    Console.Write("Enter the Unit of Measurement of the Ingridients you would like to edit");
                    recipe[index].Unit_Of_Measurement = int.Parse(Console.ReadLine().ToString());

                }

                else if (pile_index == 5)
                {
                    Console.Write("Enter the number of steps in the recipe you would like to edit");
                    recipe[index].Number_Of_Steps = int.Parse(Console.ReadLine().ToString());

                }

                else if (pile_index == 6)
                {
                    Console.Write("Enter the description of the steps in the recipe you would like to edit");
                    recipe[index].Ingrdient_Name = Console.ReadLine().ToString();

                }

                else Console.Write("Invalid Input");
                recipe[Compute_Recipe].total = float.Parse(recipe[Compute_Recipe].Number_Of_Ingridients + recipe[Compute_Recipe].Ingrdient_Name + recipe[Compute_Recipe].Ingridient_Quantity + recipe[Compute_Recipe].Unit_Of_Measurement + recipe[Compute_Recipe].Number_Of_Steps + recipe[Compute_Recipe].Recipe_Steps);

            }

            else Console.WriteLine("This option does not exist. Please re-enter the initial Recipe ID you entered and try again" + "\n");

        }

        //A separate method has been created in order to clear the recipe and/or create a recipe ID in order for the recipe to be stored within the array
        static void Clear(RecipeNeeds[] recipe, ref int Compute_Recipe)
        {
            string I;
            int index;

            if (Compute_Recipe > 0)
            {
                Console.Write("Enter recipe ID: ");
                I = Console.ReadLine();
                index = Search(recipe, I.ToString(), ref Compute_Recipe);

                if ((index != 1) && (Compute_Recipe != 0))
                {
                    if (index == (Compute_Recipe - 1))
                    {

                        clean(recipe, index);
                        --Compute_Recipe;


                        Console.WriteLine("The recipe has been cleared!");

                    }

                    else
                    {
                        for (int i = index; i < Compute_Recipe - 1; i++)
                        {
                            recipe[i] = recipe[i + 1];
                            clean(recipe, Compute_Recipe);
                            --Compute_Recipe;
                        }

                    }

                }

                else Console.WriteLine("The recipe does not check, please enter the Recipe ID you entered" + "\n");

            }
            else Console.WriteLine("There is no Recipe to delete.");
        }

        //This method was created to set the contents within the recipe to its original values
        static void clean(RecipeNeeds[] recipe, int index)
        {
            recipe[index].RecipeID = null;
            recipe[index].Ingrdient_Name = null;
            recipe[index].Recipe_Steps = null;
            recipe[index].Ingridient_Quantity = null;
            recipe[index].Number_Of_Ingridients = 0;
            recipe[index].Number_Of_Steps = 0;
            recipe[index].Unit_Of_Measurement = 0;
            recipe[index].total = 0;



        }

        //This method has been created in order to allow the user to search for anything within the recipe
        static int Search(RecipeNeeds[] recipe, string ID, ref int Compute_Recipe)
        {
            int establish = 1;

            for (int x = 0; x < Compute_Recipe && establish == -1; x++)
            {

                if (recipe[x].RecipeID == ID)
                    establish = x;

                else establish = -1;
            }

            return establish;
        }

    }


}