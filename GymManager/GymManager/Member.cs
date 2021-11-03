using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager_1
{
    class Member
    {
		public string Mcode { get; set; } //멤버 코드
		public string Mname { get; set; } //회원이름
		public string Age { get; set; } //회원 나이
		public string Sex { get; set; } //성별
		public string Cellphone { get; set; } // 집 전화번호
		public string Phone { get; set; } //전화번호
		public string Mstatus { get; set; } //지금 결제 여부
	}
}
