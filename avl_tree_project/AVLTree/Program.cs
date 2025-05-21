namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Вставить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Найти элемент");
                Console.WriteLine("4. Показать дерево");
                Console.WriteLine("5. Выход");
                Console.Write("\nВаш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите число для вставки: ");
                            if (int.TryParse(Console.ReadLine(), out int insertValue))
                            {
                                tree.Insert(insertValue);
                                Console.WriteLine("Число успешно добавлено.");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: введите корректное целое число.");
                            }
                            break;

                        case 2:
                            Console.Write("Введите число для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteValue))
                            {
                                tree.Delete(deleteValue);
                                Console.WriteLine("Операция удаления завершена.");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: введите корректное целое число.");
                            }
                            break;

                        case 3:
                            Console.Write("Введите число для поиска: ");
                            if (int.TryParse(Console.ReadLine(), out int searchValue))
                            {
                                bool found = tree.Search(searchValue);
                                Console.WriteLine(found ? "Число найдено в дереве." : "Число не найдено в дереве.");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: введите корректное целое число.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("\nДерево в скобочном формате:");
                            Console.WriteLine(tree.ToBracketFormat());
                            break;

                        case 5:
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите число от 1 до 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }
            }
        }
    }
}
