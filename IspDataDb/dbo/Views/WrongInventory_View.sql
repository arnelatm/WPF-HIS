

CREATE View [dbo].[WrongInventory_View] as 
Select  * FROM fnMovementVsInventory(1) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(3) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(4) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(5) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(6) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(7) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(8) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(9) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(10) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(11) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(12) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(13) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(14) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(15) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(16) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(17) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(18) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(19) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(20) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(21) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(22) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(23) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(24) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(25) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(26) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(27) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)
union
Select  * FROM fnMovementVsInventory(28) WHERE IsNull(QtyOnHand,0) <> IsNull(Round(QtyMovement,4),0)