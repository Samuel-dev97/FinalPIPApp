using Server.Extensions;
using Server.Models;
using System.Text;

namespace Server.Utility
{
	public class Form2HTML
	{
		public static string GetHTMLString(List<EmployeeIncentives> Data)
		{

			var sb = new StringBuilder();

			sb.Append($@"<body>
			<p style='text-align:center'>
				 <img src='https://www.necor.co.zm/img/logos/necor__cofund_.png' alt='Avator' class='avator'>
			</p>
    
			
			
			<table style='width:100%; margin-right:auto; margin-left:auto; border:1pt solid #ffffff; border-collapse:collapse'>
				<tr style='height:13.6pt'>
					<td style='width:10.45pt; border-right:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style=' color:#ffffff'>#</span>
						</p>
					</td>
					<td style='width:100.4pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='color:#ffffff'>NAME</span>
						</p>
					</td>
					<td style='width:49.1pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style=' color:#ffffff'>PAY</span>
						</p>
					</td>
					<td style='width:46.95pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style=' color:#ffffff'>FINAL SCORE</span>
						</p>
					</td>
					<td style='width:52.95pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='color:#ffffff'>PENALTY CHARGE</span>
						</p>
					</td>
					<td style='width:56.7pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='color:#ffffff'>PERCENTAGE</span>
						</p>
					</td>
                    	<td style='width:56.7pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='color:#ffffff'>HR AUTHORIZE</span>
						</p>
					</td>
                    </td>
                    	<td style='width:56.7pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='color:#ffffff'>HOD AUTHORIZE</span>
						</p>
					</td>
                     </td>
                    	<td style='width:56.7pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='color:#ffffff'>MD AUTHORIZE</span>
						</p>
					</td>
                     </td>
                    	<td style='width:56.7pt; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; border-bottom:2.25pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='color:#ffffff'>HOD COMMENT</span>
						</p>
					</td>


				</tr>");


			for (int i = 0; i < Data.Count; i++)
			{
				sb.Append(@$"
              
<tr style='height:14.15pt'>
					<td style='width:10.45pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#000000'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style=' color:#ffffff'> {Data[i].Id.ToString()}</span>
						</p>
					</td>
<td style='width:100.4pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='font-family:'Times New Roman''>{Data[i].ForeName}</span>
						</p>
					</td>
					<td style='width:100.4pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='font-family:'Times New Roman''>K{Data[i].Pay}</span>
						</p>
					</td>
					<td style='width:45.9pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='font-family:'Times New Roman''>{Data[i].FinalScore}</span>
						</p>
					</td>
					<td style='width:45.55pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='font-family:'Times New Roman''>{Data[i].PenaltyCharge}</span>
						</p>
					</td>

					<td style='width:43.95pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='font-family:'Times New Roman''>{Data[i].PippayableMonthly}</span>
						</p>
					</td>
                    <td style='width:43.95pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							 <img src='{Data[i].FirstAuth}'>
						</p>
					</td>
                    <td style='width:43.95pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<img src='{Data[i].SecondAuth}'>
						</p>
					</td>
                     <td style='width:43.95pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<img src='{Data[i].ThirdAuth}'>
						</p>
					</td>
                     <td style='width:43.95pt; border-top:2.25pt solid #ffffff; border-right:1pt solid #ffffff; border-left:1pt solid #ffffff; padding-right:4.9pt; padding-left:4.9pt; vertical-align:top; background-color:#e7e7e7'>
						<p style='text-align:justify; widows:0; orphans:0; font-size:9pt'>
							<span style='font-family:'Times New Roman''>{Data[i].Comment1}</span>
						</p>
					</td>

				</tr>
"
				);
			}

			sb.AppendFormat(@$"
</table>	
<hr>
</div
    
<p style='text-align:left'>
				 Head of Deprtment : Kabayi
              
			</p>
<hr>
<hr>
<p style='margin - top:3.8pt; margin - left:35.35pt; font - size:6pt'>
				<strong><u> TOTAL INCENTIVE PAY TARGET </u></strong >
			</p>
<p style='text-align:left'>
	<strong><u> Below 39% = 100, 40% - 59% = 80 , 60% - 79% = 50, 80% - 90% = 20, 91% - 99% = 5</u></strong >
              
			</p>

");


			return sb.ToString();

			//Another 


		}

      
    }
}


