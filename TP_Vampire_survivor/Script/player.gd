extends CharacterBody2D

@onready var animSprite: AnimatedSprite2D = $AnimatedSprite2D


const SPEED = 200.0
const JUMP_VELOCITY = -400.0


func _physics_process(delta: float) -> void:

	var HDirection := Input.get_axis("left", "right")
	var VDirection := Input.get_axis("up", "down")
		
	if HDirection < 0:
		animSprite.play("side_walk")
		animSprite.flip_h = true	
	elif HDirection > 0 : 
		animSprite.play("side_walk")
		animSprite.flip_h = false
	elif VDirection > 0:
		animSprite.play("down_walk")
	elif VDirection < 0:
		animSprite.play("up_walk")
	else:
		animSprite.play("idle")
	
	if HDirection || VDirection:
		velocity.x = HDirection * SPEED
		velocity.y = VDirection * SPEED
		
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.y = move_toward(velocity.y, 0, SPEED)

	move_and_slide()
