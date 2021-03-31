using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Domain.Entities.Targets;

namespace Polaris.Domain.Entities.Activities
{
    public class UserStoryBacklog : LinkedList<UserStory>
    {
        public Guid UserStoryBacklogId { get; set; } = Guid.NewGuid();

        public int TotalUserStories => Count;
        
        public int TotalWorkItems =>  this
            .Select(x => x.UserTasks)
            .Sum(userTasks => userTasks.Count);

        public IEnumerator<UserStory> StoryPriorityIterator()
        {
            var orderedByPriority = this.OrderByDescending(x => x.Priority.Value);

            foreach (var userStory in orderedByPriority)
            {
                yield return userStory;
            }
        }

        public void Add(UserStory userStory)
        {
            AddLast(userStory);
        }

        public void Sort()
        {
            QuickSort();
        }

        private static class PriorityComparer
        {
            public static Comparer<T> Create<T>(Comparison<T> comparison) where T : UserStory
            {
                if (comparison == null) throw new ArgumentNullException("comparison");
                return new ComparisonComparer<T>(comparison);
            }
            private sealed class ComparisonComparer<T> : Comparer<T> where T : UserStory
            {
                private readonly Comparison<T> _comparison;
                public ComparisonComparer(Comparison<T> comparison)
                {
                    _comparison = comparison;
                }
                public override int Compare(T x, T y)
                {
                    return _comparison(x, y);
                }
            }
        }
        
        private void QuickSort()
        {
            if (Count <= 1) return;

            var comparer = PriorityComparer.Create<UserStory>((story1, story2) =>
                story1.Priority.Value.CompareTo(story2.Priority.Value));

            InPlaceSort(First, Last, comparer);
        }

        private static void InPlaceSort(LinkedListNode<UserStory> head, LinkedListNode<UserStory> tail, IComparer<UserStory> comparer)
        {
            while (true)
            {
                if (head == tail) return;

                static void Swap(LinkedListNode<UserStory> a, LinkedListNode<UserStory> b)
                {
                    var tmp = a.Value;
                    a.Value = b.Value;
                    b.Value = tmp;
                }

                var pivot = tail;
                var node = head;
                while (node?.Next != pivot)
                {
                    if (comparer.Compare(node!.Value, pivot?.Value!) > 0)
                    {
                        Swap(pivot, pivot.Previous!);
                        Swap(node, pivot);
                        pivot = pivot.Previous;
                    }
                    else
                        node = node.Next;
                }

                if (comparer.Compare(node.Value, pivot?.Value!) > 0)
                {
                    Swap(node, pivot);
                    pivot = node;
                }

                if (head != pivot) 
                    InPlaceSort(head, pivot.Previous!, comparer);
                if (tail != pivot)
                {
                    head = pivot.Next!;
                    continue;
                }

                break;
            }
        }
    }
}