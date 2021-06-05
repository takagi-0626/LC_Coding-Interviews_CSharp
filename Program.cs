using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetcodeConsole
{
    class Program
    {
        #region 重建二叉树_散列表
        public static Hashtable hashtable = new Hashtable();
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine(HammingWeight(0b110));
            Console.ReadKey();
        }
        #region 1.数组中的重复数字
        #region 哈希表实现
        //public int FindRepeatNumber(int[] nums)  
        //{
        //    HashSet<int> hashList = new HashSet<int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (hashList.Contains(nums[i]))
        //            return nums[i];
        //        hashList.Add(nums[i]);
        //    }
        //    return -1;
        //}
        #endregion

        #region 原地排序
        public static int FindRepeatNumber(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == i)
                    continue;
                if (nums[nums[i]] != nums[i])
                {
                    int temp = nums[nums[i]];
                    nums[nums[i]] = nums[i];
                    nums[i] = temp;
                }
                else
                    return nums[i];
            }
            return -1;
        }
        #endregion
        #endregion

        #region 2.二维数组中的查找 (排序二叉树？)

        //public static bool FindNumberIn2DArray(int[][] matrix, int target)
        //{
        //    if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        //    {
        //        return false;
        //    }
        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        if (matrix[i][matrix[i].Length - 1] >= target)
        //        {
        //            for (int j = matrix[i].Length - 1; j >= 0; j--)
        //            {
        //                if (matrix[i][j] == target)
        //                {
        //                    return true;
        //                }
        //            }
        //        }

        //    }

        //    return false;
        //}

        #endregion

        #region 6.从尾到头打印链表

        #region 数组实现
        //public static int[] ReversePrint(LinkedListNode<int> head)
        //{
        //    LinkedListNode<int> tempHead = head;
        //    int arrayLength = 1;
        //    if (head != null)
        //    {
        //        while (tempHead.Next != null)
        //        {
        //            arrayLength++;
        //            tempHead = tempHead.Next;
        //        }
        //    }
        //    else arrayLength = 0;

        //    int[] reverseArray = new int[arrayLength];
        //    for (int i = arrayLength - 1; i >= 0; i--)
        //    {
        //        reverseArray[i] = head.Value;
        //        head = head.Next;
        //    }
        //    return reverseArray;
        //}
        #endregion

        #region 栈实现
        public static int[] ReversePrint(LinkedListNode<int> head)
        {
            Stack<int> rs = new Stack<int>();

                while (head!= null)
                {
                    rs.Push(head.Value);
                    head = head.Next;
                }
            int j = rs.Count;
            int[] ri = new int[j];
            for (int i = 0; i < j; i++)
            {
                ri[i] = rs.Pop();
            }
            return ri;
        }


        #endregion

        #endregion

        #region 7.重建二叉树

        #region 递归实现
        public static TreeNode Mybuilder(int[] preorder,int[] inorder,int preorder_left,int preorder_right,int inorder_left,int inorder_right)
        {
            if (preorder_left > preorder_right)
            {
                return null;
            }
            TreeNode root = new TreeNode(preorder[preorder_left]);
            int inorder_root=(int)hashtable[preorder[preorder_left]];
            int inorder_lSize = inorder_root - inorder_left;
            root.left= Mybuilder(preorder, inorder, preorder_left + 1, preorder_left + inorder_lSize, inorder_left,  inorder_root - 1);
            root.right = Mybuilder(preorder, inorder, preorder_left + inorder_lSize + 1, preorder_right, inorder_root + 1, preorder_right);
            return root;
        }

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            
 
            for (int i = 0; i < preorder.Length; i++)
            {
                hashtable.Add(inorder[i], i);
            }
            return Mybuilder(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }
        #endregion

        #region ----

        #endregion

        #endregion

        #region 9.两个栈实现队列

        public class CQueue
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            public CQueue()
            {

                Stack<int> s1 = this.s1;
                Stack<int> s2 = this.s2;

            }

            public void AppendTail(int value)
            {
                s1.Push(value);
            }

            public int DeleteHead()
            {
                int j=-1;
                int s1C = s1.Count;
                //if (s1.Count==0&&s2.Count==0)
                //{
                //    return -1;
                //}
                //else
                //{
                    if (s2.Count == 0)
                    {
                        for (int i = 0; i < s1C; i++)
                        {
                            s2.Push(s1.Pop());
                        }
                    }
                    if (s2.Count > 0)
                    {
                        j = s2.Pop();
                    }
                    return j;
                
            }
        }

        #endregion

        #region 10-I斐波那契数列

        #region 递归实现（效率不通过，未取模）（记忆递归？）
        //public static int Fib(int n)
        //{
        //    ArrayList fib = new ArrayList() { 0, 1 };

        //    if (n <= 1)
        //    {
        //        return (int)fib[n];
        //    }
        //    else
        //    {
        //        return Fib(n - 1) + Fib(n - 2);
        //    }
        //}
        #endregion
        #region DP？(注意取模)

        public static int Fib(int n)
        {
            int a=0, b=1, s;
            for (int i = 0; i < n; i++)
            {
                s = (a + b) % 1000000007;
                a = b;
                b = s;
            }
            return a;
        }

        #endregion
        #endregion

        #region 10-II青蛙跳台阶




        #endregion

        #region 11.旋转数组

        public static int MinArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    return numbers[i + 1];
                }
            }

            return 0;
        }

        #endregion

        #region 12.矩阵中的路径

        #region DFS

        public bool Exist(char[][] board, string word)
        {
            char[] tempWord = word.ToCharArray();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (DFS(board, tempWord, i, j, 0))
                        return true;
                }
            }
            return false;

        }

        public bool DFS(char[][] board, char[] word, int i, int j, int k)
        {
            if (i < 0 || i > board.Length - 1 || j < 0 || j > board[0].Length - 1 || word[k] != board[i][j])
            {
                return false;
            }
            if (k == word.Length - 1)
            {
                return true;
            }
            board[i][j] = '\0';
            bool result = DFS(board, word, i, j + 1, k + 1) || DFS(board, word, i, j - 1, k + 1) || DFS(board, word, i + 1, j, k + 1) || DFS(board, word, i - 1, j, k + 1);
            board[i][j] = word[k];
            return result;
        }


        #endregion

        #region BFS



        #endregion

        #endregion

        #region 13.机器人的运动范围(DFS,BFS)

        #region DFS
        //public int MovingCount(int m, int n, int k)
        //{
        //    bool[,] flag = new bool[m, n];
        //    return DFS(m, n, k, 0, 0, flag);
        //}
        //public int DFS(int m, int n, int k, int i, int j, bool[,] flag)
        //{
        //    if (i < 0 || i >= m || j < 0 || j >= n || Sum(m, n) > k || flag[i, j] == true)
        //    {
        //        return 0;
        //    }
        //    flag[i, j] = true;
        //    return 1 + DFS(m, n, k, i, j + 1, flag) + DFS(m, n, k, i + 1, j, flag);

        //}
        //public int Sum(int m, int n)
        //{
        //    return m / 10 + m % 10 + n / 10 + n % 10;
        //}


        #endregion

        #region BFS

        public int MovingCount(int m, int n, int k)
        {
            int result = 0;
            bool[,] tempNum = new bool[m, n] ;
            Queue<int[]> bfsQueue = new Queue<int[]> ();
            bfsQueue.Enqueue(new int[] { 0,0});

            while (bfsQueue.Count > 0)
            {
                int[] temp=bfsQueue.Dequeue();
                int x=temp[0], y = temp[1];
                if (x >= m || y >= n || Sum(x, y) > k || tempNum[x,y] == true)
                    continue;
                tempNum[x, y] = true;
                result++;
                bfsQueue.Enqueue(new int[] { x + 1, y });
                bfsQueue.Enqueue(new int[] { x, y + 1 });
            }

            return result;
        }

        public int Sum(int m, int n)
        {
            return m / 10 + m % 10 + n / 10 + n % 10;
        }


        #endregion


        #endregion

        #region 14-I剪绳子

        public int CuttingRope(int n)
        {
            

            return 0;
        }

        #endregion

        #region 15.二进制中1的个数

        public static int HammingWeight(uint n)
        {
            int res = 0;
            while(n!=0)
            {
                n &=n-0b1;
                Console.WriteLine(n);
                res++;
            }
            return res;
        }


        #endregion

        #region 17.打印从1到最大的n位数(大数时的全排列问题，循环递归实现)

        public int[] PrintNumbers(int n)
        {
            int[] res=new int[n];
            return res;
        }

        public void DfS()
        {
            
        }


        #endregion

        #region 18.删除链表的节点

        //public ListNode DeleteNode(ListNode head,int val)
        //{
        //    if (head.val == val)
        //        return head = head.next;
        //    ListNode tempHeadNode = head;

        //    while (head.next != null && head.next.val != val)
        //    {
        //        head = head.next;
        //    }
        //    head.next = head.next.next;
        //    return tempHeadNode;
        //}

        public ListNode DeleteNode(ListNode head, int val)
        {
            ListNode pre = head, cur = head.next;
            if (head == null)
                return null;
            while (cur.val != val && cur != null)
            {
                pre = cur;
                cur = cur.next;
            }
            if (cur != null)
            {
                pre.next = cur.next;
            }
            return head;

        }

        #endregion

        #region 21.调整数组顺序

        public int[] Exchange(int[] nums)
        {
            int j = 0,temp;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]%2==1)
                {
                    temp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = nums[j];
                    j++;
                }
            }
            return nums;
        }

        #endregion

        #region 24.反转链表

        public ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            ListNode cur = head;
            ListNode temp;

            while (cur!=null)
            {
                temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            return pre;
        }

        #endregion

        #region 25.合并两个排序的链表
        //public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        //{
        //    if (l1 == null)
        //        return l2;

        //    ListNode prel1 = new ListNode(0), curl1, curl2 = l2, temp = null;
        //    prel1.next = l1;
        //    curl1 = l1;
        //    l1 = prel1;

        //    while (curl2 != null && curl1 != null)
        //    {
        //        if (curl1.val >= curl2.val)
        //        {
        //            temp = curl2.next;
        //            curl2.next = curl1;
        //            prel1.next = curl2;


        //            curl2 = temp;
        //            prel1 = prel1.next;

        //            continue;
        //        }
        //        else
        //        {
        //            prel1 = prel1.next;
        //            curl1 = curl1.next;
        //        }
        //        if (curl1 == null)
        //        {
        //            prel1.next = curl2;
        //            break;
        //        }
        //    }
        //    return l1.next;
        //}
        #region 伪头结点
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            return l1;
        }

        #endregion


        #endregion

        #region 27.镜像二叉树

        public TreeNode MirrorTree(TreeNode root)
        {
            if (root==null)
            {
                return null;
            }
            TreeNode tempNode=root.right;
            root.right=MirrorTree(root.left);
            root.left = MirrorTree(tempNode);
            return root;
        }

        #endregion
    }

    #region 重建二叉树_节点
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
    }
    #endregion


    #region 单链表节点

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    #endregion

}
