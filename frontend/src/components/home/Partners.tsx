import { FaAtlassian, FaAws, FaBattleNet, FaApple, FaAmazonPay } from "react-icons/fa";
import { PartnerItem, PartnerRow, PartnerSection, Partnertext, SericesSection } from "../../styledComponent/home";

const Partners = () => {
    return (
        <>
            <SericesSection>
                <PartnerSection>
                    <Partnertext>Trusted by 1000+ companies</Partnertext>
                    <PartnerRow>
                        <PartnerItem>
                            <FaAtlassian className="home-img"/>
                        </PartnerItem>
                        <PartnerItem>
                            <FaAws  className="home-img"/>
                        </PartnerItem>
                        <PartnerItem>
                            <FaBattleNet  className="home-img"/>
                        </PartnerItem>
                        <PartnerItem>
                            <FaApple  className="home-img"/>
                        </PartnerItem>
                        <PartnerItem>
                            <FaAmazonPay  className="home-img"/>
                        </PartnerItem>
                    </PartnerRow>
                    {/* <FaAirbnb /> */}
                </PartnerSection>
            </SericesSection>
        </>
    )
}

export default Partners