namespace CustomGenericLinkedList
{
    public class MyLinkedListNode<TNode>
    {
        public TNode Value { get; set; }
        public MyLinkedListNode<TNode> Prev { get; set; }
        public MyLinkedListNode<TNode> Next { get; set; }

        public MyLinkedListNode(TNode value)
        {
            this.Value = value;
        }
    }
}
