export class userRegister{
    Id:number;
    FullName:string;
    EmailId:string;
    Password:string;
    ConfirmPassword:string;
    constructor(){
        this.Id=0,
        this.FullName='',
        this.EmailId='',
        this.Password='',
        this.ConfirmPassword=''
    }
}

export class UserLogin{
    EmailId:string;
    Password:string;
    constructor(){
        this.EmailId='';
        this.Password='';
    }

}
export class EventsObj{
    id:string= "";
    title:string= "";
    description:string= "";
    startDate:Date=new Date();
    endDate:Date=new Date();
    venueName:string= "";
    capacity: number=0;
    imageUrl: string= "";
    IsBooked:boolean=false;
    price:number=0;
    isActive: boolean=false;
    createdBy:string= "";
    createdOn:Date=new Date();
}
export class EventBooking{
bookingId:number=0;
eventId:string="";
userId:number=0;
status="";
eventTitle="";
eventVenue="";
eventDescription="";
eventStartDate:Date=new Date;
eventEndDate:Date=new Date;
eventPrice:number=0;
}

export class ConfirmBookingRequest{
UserId :number=0;
EventId:string="";
 Status:string="";
UserName :string="";
CreatedOn:Date=new Date();
}