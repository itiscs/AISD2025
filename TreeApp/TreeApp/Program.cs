using TreeApp;

Tree tree = new Tree("(-67,(4,(33,44,66),45),(-1,7,(12,13,14)))");

//String str = Console.ReadLine();

//Tree tree = new Tree(str);

//tree.Root = null;


Console.WriteLine(tree.TreeSum());

tree.HorizontalRound();
Console.WriteLine();

Console.WriteLine(tree);





Tree<int> tree2 = new Tree<int>("(-67,(4,(33,44,66),45),(-1,7,(12,13,14)))", int.Parse);

Console.WriteLine(tree2);


Tree<double> tree3 = new Tree<double>("(-7.0,(4.2,(33.33,44.44,66.66),45.9),(-1,7,(12,13,14)))", (s) => double.Parse(s.Replace('.',',')));

Console.WriteLine(tree3);


Tree<string> tree4 = new Tree<string>("(aaa,(bbbb,(cccc,ddddd,eeeee),fffff),(gggggg,hhhh,(xxxxx,yyyyyy,zzzzzz)))", s => s);

Console.WriteLine(tree4);