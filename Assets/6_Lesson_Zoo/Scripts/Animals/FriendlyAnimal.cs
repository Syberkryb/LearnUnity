using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6
{
    public abstract class FriendlyAnimal : Animal, IFriendlyAnimal
    {
        public AnimalPen Pen;
    }
}