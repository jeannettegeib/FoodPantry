export const getMax = ( familySizeInteger, category ) => {
    let max=0;
        switch(familySizeInteger) {
            
            case 1:
                max=category.onePerson;
              
            case 2:
                max=category.twoPeople
                
            case 3:
                max=category.threeToFourPeople
               
            case 4:
                max=category.threeToFourPeople
               
            case 5:
                max=category.fiveToSixPeople
                
            case 6:
                max=category.fiveToSixPeople
               
            case 7:
                max=category.sevenToEightPeople
                
            case 8:
                max=category.sevenToEightPeople
                
            case 9:
                max=category.ninePlusPeople
                
            default:
                max=category.ninePlusPeople         
    };
    return max
}
