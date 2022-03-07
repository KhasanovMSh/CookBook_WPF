using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace DataLibrary
{
    public static class DataController
    {
        public static bool Regin(string userType, string login, string password, string name, string surname)
        {
            if (userType == "" || login == "" || password == "" || name == "" || surname == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
                return false;
            }
            else
            {
                string[] dataLogin = login.Split('@'); // делим строку на две части
                if (dataLogin.Length == 2) // проверяем если у нас две части
                {
                    string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                    if (data2Login.Length == 2)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Укажите логин в форме х@x.x");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Укажите логин в форме х@x.x");
                    return false;
                }

                using (RecipeBaseEntities db = new RecipeBaseEntities())
                {
                    if (db.User.Where(p => p.Login.Equals(login)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        return false;
                    }
                }

                if (password.Length >= 6)
                {
                    bool en = true; // английская раскладка
                    bool symbol = false; // символ
                    bool number = false; // цифра

                    for (int i = 0; i < password.Length; i++) // перебираем символы
                    {
                        if (password[i] >= 'А' && password[i] <= 'Я') en = false; // если русская раскладка
                        if (password[i] >= '0' && password[i] <= '9') number = true; // если цифры
                        if (password[i] == '_' || password[i] == '-' || password[i] == '!') symbol = true; // если символ
                    }

                    if (!en)
                    {
                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                        return false;
                    }
                    else if (!symbol)
                    {
                        MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                        return false;
                    }

                    else if (!number)
                    {
                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                        return false;
                    }

                    if (en && symbol && number) // проверяем соответствие
                    {

                    }
                }
                else
                {
                    MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                    return false;
                }

                try
                {
                    using (RecipeBaseEntities db = new RecipeBaseEntities())
                    {
                        var tempUser = new User() { UserType = userType, Login = login, Password = password, Name = name, Surname = surname };
                        db.User.Add(tempUser);
                        db.SaveChanges();
                        if (userType == "client")
                        {
                            CurrentUser.currentUser = tempUser;
                        }
                        MessageBox.Show("Пользователь добавлен!", "Успешно!");
                    }
                    return true;
                }
                catch
                {
                    MessageBox.Show("Невозможно добавить пользователя!", "Ошибка", MessageBoxButton.OK);
                    return false;
                }
            }
        }

        public static bool Login(string login, string password)
        {
            if (login.Length > 0) // проверяем введён ли логин     
            {
                if (password.Length > 0) // проверяем введён ли пароль         
                {
                    try
                    {
                        using (RecipeBaseEntities db = new RecipeBaseEntities())
                        {
                            CurrentUser.currentUser = db.User.Where(p => p.Login.Equals(login) && p.Password.Equals(password)).FirstOrDefault();
                        }
                        if (CurrentUser.currentUser != null)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль"); // выводим ошибку    
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите логин"); // выводим ошибку 
                return false;
            }
        }

        public static List<Recipe> LoadRecipe()
        {
            using (RecipeBaseEntities db=new RecipeBaseEntities())
            {
                return db.Recipe.ToList();
            }
        }

        public static bool AddRecipe(string name, string categories, string ingridientsAndSteps, string imagePath)
        {
            try
            {
                using (RecipeBaseEntities db = new RecipeBaseEntities())
                {
                    var tempRecipe = new Recipe() { Name = name, Categories = categories, Ingridients = ingridientsAndSteps, ImagePreview = File.ReadAllBytes(imagePath), IsClientRecipe=false };
                    db.Recipe.Add(tempRecipe);
                    db.SaveChanges();
                    MessageBox.Show("Рецепт успешно сохранен");
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить рецепт");
                return false;
            }

        }

        public static List<User> LoadUsers()
        {
            using (RecipeBaseEntities db = new RecipeBaseEntities())
            {
                return db.User.ToList();
            }
        }

        public static bool UpdateUser(User tempUser)
        {
            if (tempUser.UserType == "" || tempUser.Login == "" || tempUser.Password == "" || tempUser.Name == "" || tempUser.Surname == "")
            {
                MessageBox.Show("Не оставляйте поле пустым!", "Ошибка!");
                return false;
            }
            try
            {
                using (RecipeBaseEntities db=new RecipeBaseEntities())
                {
                    var editableUser = db.User.Where(p=>p.ID_User.Equals(tempUser.ID_User)).FirstOrDefault();
                    editableUser.UserType = tempUser.UserType;
                    editableUser.Login = tempUser.Login;
                    editableUser.Password = tempUser.Password;
                    editableUser.Name = tempUser.Name;
                    editableUser.Surname = tempUser.Surname;
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно изменить данные пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        public static bool DeleteUser(User tempUser)
        {
            try
            {
                using (RecipeBaseEntities db = new RecipeBaseEntities())
                {
                    var delitableUser = db.User.Where(p => p.ID_User.Equals(tempUser.ID_User)).FirstOrDefault();
                    db.User.Remove(delitableUser);
                    db.SaveChanges();
                }
                MessageBox.Show("Пользователь удален!");
                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }
    }
}
