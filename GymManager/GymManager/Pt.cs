using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager_1
{
    class Pt
    {
        public string Mcode { get; set; } //멤버 코드
        public string Mname { get; set; } //회원이름
        public int BM { get; set; } //Pt 받기 전 근육량
        public int NM { get; set; } //현재 근육량
        public int BF { get; set; } //Pt 받기 전 체지방량
        public int NF { get; set; } //현재 체지방량
        public int BW { get; set; } //Pt 받기 전 몸무게
        public int NW { get; set; } //현재 몸무게
        public string Ptst { get; set; } //PT 여부
    }
}
