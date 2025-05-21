namespace AVLTree
{
    public class AVLTree
    {
        private AVLNode? _root;

        public AVLTree()
        {
            _root = null;
        }

        private int Height(AVLNode? node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(AVLNode? node)
        {
            return node == null ? 0 : Height(node.Left) - Height(node.Right);
        }

        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left!;
            AVLNode T2 = x.Right!;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right!;
            AVLNode T2 = y.Left!;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public void Insert(int value)
        {
            _root = InsertRec(_root, value);
        }

        private AVLNode InsertRec(AVLNode? node, int value)
        {
            if (node == null)
                return new AVLNode(value);

            if (value < node.Value)
                node.Left = InsertRec(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRec(node.Right, value);
            else
                return node; // Duplicate values are not allowed

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && value < node.Left!.Value)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && value > node.Right!.Value)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && value > node.Left!.Value)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && value < node.Right!.Value)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        public bool Search(int value)
        {
            return SearchRec(_root, value);
        }

        private bool SearchRec(AVLNode? node, int value)
        {
            if (node == null)
                return false;

            if (value == node.Value)
                return true;

            if (value < node.Value)
                return SearchRec(node.Left, value);

            return SearchRec(node.Right, value);
        }

        public void Delete(int value)
        {
            _root = DeleteRec(_root, value);
        }

        private AVLNode? DeleteRec(AVLNode? node, int value)
        {
            if (node == null)
                return null;

            if (value < node.Value)
                node.Left = DeleteRec(node.Left, value);
            else if (value > node.Value)
                node.Right = DeleteRec(node.Right, value);
            else
            {
                // Node with only one child or no child
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                node.Value = MinValue(node.Right);

                // Delete the inorder successor
                node.Right = DeleteRec(node.Right, node.Value);
            }

            if (node == null)
                return null;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RightRotate(node);

            // Left Right Case
            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = LeftRotate(node.Left!);
                return RightRotate(node);
            }

            // Right Right Case
            if (balance < -1 && GetBalance(node.Right) <= 0)
                return LeftRotate(node);

            // Right Left Case
            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RightRotate(node.Right!);
                return LeftRotate(node);
            }

            return node;
        }

        private int MinValue(AVLNode node)
        {
            int minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }

        public string ToBracketFormat()
        {
            return ToBracketFormatRec(_root);
        }

        private string ToBracketFormatRec(AVLNode? node)
        {
            if (node == null)
                return "";

            if (node.Left == null && node.Right == null)
                return $"{node.Value}";

            return $"({node.Value}, {ToBracketFormatRec(node.Left)}, {ToBracketFormatRec(node.Right)})";
        }
    }
} 