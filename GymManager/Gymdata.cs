using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager_1
{
    class Gymdata
    {
        public string Mcode { get; set; } //멤버 코드
        public string Mname { get; set; } //회원이름
        public string Boxinfo { get; set; } //보관함 번호
        public DateTime Startperiod { get; set; } //헬스 시작 기간
        public DateTime Endperiod { get; set; } //헬스 종료 기간
    }
}
