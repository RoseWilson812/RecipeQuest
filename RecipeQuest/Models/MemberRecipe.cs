using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeQuest.Models
{
    public class MemberRecipe
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public MemberRecipe()
        {
        }
    }
}
